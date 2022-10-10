using ClaimsSubmission.Application.UseCases.BatchFiles.Services;
using ClaimsSubmission.Application.UseCases.CodesValidation.Events.CodesVerified;
using ClaimsSubmission.Application.UseCases.Common;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using ClaimsSubmission.Domain.SharedKernel;
using MediatR;

namespace ClaimsSubmission.Application.UseCases.CodesValidation.Commands;

public class ValidateCodesCommandHandler : JobCommandHandlerBase<ValidateCodesCommand>
{
    private readonly IRepository _repository;
    private readonly IBatchClaimsValidator _batchClaimsValidator;
    private readonly ICurrentDateTime _currentDateTime;
    private readonly IMediator _mediator;

    public ValidateCodesCommandHandler(
        IRepository repository,
        IBatchClaimsValidator batchClaimsValidator,
        ICurrentDateTime currentDateTime,
        IMediator mediator)
    {
        _repository = repository;
        _batchClaimsValidator = batchClaimsValidator;
        _currentDateTime = currentDateTime;
        _mediator = mediator;
    }

    public override async Task<Unit> Handle(ValidateCodesCommand command, CancellationToken cancellationToken)
    {
        await base.Handle(command, cancellationToken);

        LogInfo($"Validating claim codes for {command.BatchFileId.Value}");

        var validationResult = await _batchClaimsValidator.ValidateCodes(command.FilePath, cancellationToken);

        await _mediator.Publish(new CodesVerifiedEvent(command.BatchFileId, validationResult), cancellationToken);

        LogInfo($"Codes verified for {command.BatchFileId.Value}");

        return Unit.Value;
    }
}