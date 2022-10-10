using ClaimsSubmission.Application.UseCases.CodesValidation.Commands;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Events;
using Hangfire;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.EventHandlers.BatchFileAggregate.FileUniquenessChecked;

public class UniquenessValidationSucceededEventHandler : INotificationHandler<UniquenessValidationSucceededEvent>
{
    private readonly ILogger<UniquenessValidationSucceededEvent> _logger;
    private readonly IRepository _repository;
    private readonly IBackgroundJobClient _backgroundJobClient;

    public UniquenessValidationSucceededEventHandler(
        ILogger<UniquenessValidationSucceededEvent> logger,
        IRepository repository,
        IBackgroundJobClient backgroundJobClient)
    {
        _logger = logger;
        _repository = repository;
        _backgroundJobClient = backgroundJobClient;
    }

    public async Task Handle(UniquenessValidationSucceededEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("@{BatchFile} succeeded uniqueness validation", notification);

        var batchFile = await _repository.Get(notification.Id);

        var filePath = Path.Combine(batchFile.HealthcareFacilityId.AccreditationCode, batchFile.FileInternalName);

        _backgroundJobClient.Enqueue<CodesVerificationJob>(
            job => job.Execute(new ValidateCodesCommand
            {
                BatchFileId = notification.Id,
                FilePath = filePath
            }, null));
    }
}