using ClaimsAutoProcessing.Api.Application.Services;
using ClaimsAutoProcessing.Api.Application.Services.AutoAcceptRules;
using ClaimsAutoProcessing.Api.Domain;
using ClaimsAutoProcessing.Api.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAutoProcessing.Api.Application.Commands;

public class StartAutoVettingCommandHandler : IRequestHandler<StartAutoVettingCommand>
{
    private readonly ClaimsAutoProcessingContext _context;
    private readonly InsuranceValidationService _insuranceValidationService;
    private readonly TariffsCorrectionService _tariffsCorrectionService;

    public StartAutoVettingCommandHandler(
        ClaimsAutoProcessingContext context,
        InsuranceValidationService insuranceValidationService,
        TariffsCorrectionService tariffsCorrectionService)
    {
        _context = context;
        _insuranceValidationService = insuranceValidationService;
        _tariffsCorrectionService = tariffsCorrectionService;
    }

    public async Task<Unit> Handle(StartAutoVettingCommand request, CancellationToken cancellationToken)
    {
        var batch = await _context
            .Batches
            .Include(i => i.Claims)
            .FirstAsync(i => i.Id == request.BatchId, cancellationToken);

        var claims = batch.Claims;

        var insuranceCheckTasks = claims
            .Select(batchClaim => _insuranceValidationService.IsValid(batchClaim))
            .ToList();

        var insuranceValidationResults = await Task.WhenAll(insuranceCheckTasks);

        claims
            .Where(c =>
                insuranceValidationResults
                    .Any(v => v.ClaimId == c.Id && v.InsuranceValid == false))
            .ToList()
            .ForEach( c => c.PatientInsuranceValidity = false);

        var validClaims = claims
            .Where(c => insuranceValidationResults
                .Any(v => v.ClaimId == c.Id && v.InsuranceValid))
            .ToList();

        var codesCorrectionResult = validClaims
            .Select(batchClaim => _tariffsCorrectionService.CorrectTariffs(batchClaim))
            .ToList();

        var tariffsCorrectionResults = await Task.WhenAll(codesCorrectionResult);

        foreach (var claim in validClaims)
        {
            claim.FinalAmount = tariffsCorrectionResults.Any(t => t.ClaimId == claim.Id)
                ? tariffsCorrectionResults.First(t => t.ClaimId == claim.Id).ValidPrice
                : claim.OriginalAmount;
        }

        foreach (var claim in validClaims)
        {
            var isAutoAccepted = await new ClaimNotExpensiveRule().Check(claim);
            if (isAutoAccepted)
            {
                claim.VettingStatus = VettingStatus.Accepted;
                break;
            }

            isAutoAccepted = await new AntenatalDiagnosisMeetsPriceRangeRule().Check(claim);
            if (isAutoAccepted)
            {
                claim.VettingStatus = VettingStatus.Accepted;
                break;
            }
        }

        var claimsToAuditCount = (int)(batch.Claims.Count * 0.3);
        var claimsToAudit = validClaims
            .Where(c => c.VettingStatus == VettingStatus.Accepted)
            .OrderBy(_ => Guid.NewGuid())
            .Take(claimsToAuditCount == 0 ? 1 : claimsToAuditCount)
            .ToList();

        claimsToAudit.ForEach(c => c.SelectedForAudit = true);

        batch.AutoProcessingCompleted = true;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}