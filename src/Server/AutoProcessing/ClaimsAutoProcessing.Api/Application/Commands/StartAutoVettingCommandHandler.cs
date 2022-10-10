using ClaimsAutoProcessing.Api.Domain;
using ClaimsAutoProcessing.Api.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAutoProcessing.Api.Application.Commands;

public class StartAutoVettingCommandHandler : IRequestHandler<StartAutoVettingCommand>
{
    private readonly ClaimsAutoProcessingContext _context;

    public StartAutoVettingCommandHandler(ClaimsAutoProcessingContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(StartAutoVettingCommand request, CancellationToken cancellationToken)
    {
        var batch = await _context
            .Batches
            .Include(i => i.Claims)
            .FirstAsync(i => i.Id == request.BatchId, cancellationToken);


        //_context.Batches.Add(new Batch
        //{
        //    CreatedAt = DateTime.UtcNow,
        //    HealthcareFacilityCode = "123",
        //    Claims = new List<BatchClaim>
        //    {
        //        new BatchClaim
        //        {
        //            DiagnosisCode = "abc",
        //            PatientBirthDate = DateTime.UtcNow,
        //            PatientInsuranceNumber = "zxc",
        //            TotalAmount = 10
        //        }
        //    }
        //});

        //await _context.SaveChangesAsync(cancellationToken);

        //var batch = _context.Batches.FirstOrDefault(i => i.HealthcareFacilityCode == "123");

        return Unit.Value;
    }
}