using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Events;
using ClaimsSubmission.Domain.SharedKernel;
using Hangfire;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.EventHandlers.BatchFileAggregate.BatchFileUploaded;

public class BatchFileUploadedEventHandler : INotificationHandler<BatchFileUploadedEvent>
{
    private readonly ILogger<BatchFileUploadedEventHandler> _logger;
    private readonly IBackgroundJobClient _backgroundJobClient;

    public BatchFileUploadedEventHandler(
        ILogger<BatchFileUploadedEventHandler> logger,
        IBackgroundJobClient backgroundJobClient)
    {
        _logger = logger;
        _backgroundJobClient = backgroundJobClient;
    }

    public Task Handle(BatchFileUploadedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("@{BatchFile} has been upload", notification);

        _backgroundJobClient.Enqueue<BatchFileUniquenessCheckJob>(
            job => job.Execute(new ValidateFileUniquenessCommand
            {
                BatchFileId = notification.Id
            }, null));

        return Task.CompletedTask;
    }
}