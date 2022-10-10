using ClaimsSubmission.Application.UseCases.BatchFiles.EventHandlers.BatchFileAggregate.BatchFileUploaded;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Events;
using ClaimsSubmission.Domain.SharedKernel;
using Hangfire;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClaimsSubmission.Application.UseCases.CodesValidation.Events.CodesVerified;

public class CodesVerifiedEventHandler : INotificationHandler<CodesVerifiedEvent>
{
    private readonly ILogger<BatchFileUploadedEventHandler> _logger;
    private readonly IRepository _repository;
    private readonly ICurrentDateTime _currentDateTime;

    public CodesVerifiedEventHandler(
        ILogger<BatchFileUploadedEventHandler> logger,
        IRepository repository,
        ICurrentDateTime currentDateTime)
    {
        _logger = logger;
        _repository = repository;
        _currentDateTime = currentDateTime;
    }

    public async Task Handle(CodesVerifiedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Codes verified for @{BatchFileId} has been upload", notification.Id);
        
        var batchFile = await _repository.Get(notification.Id);

        batchFile?.SaveValidationResult(notification.VerificationResult, _currentDateTime);

        await _repository.SaveChanges(cancellationToken);
    }
}