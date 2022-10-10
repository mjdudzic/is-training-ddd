using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Events;
using Hangfire;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.EventHandlers.BatchFileAggregate.FileUniquenessChecked;

public class UniquenessValidationFailedEventHandler : INotificationHandler<UniquenessValidationFailedEvent>
{
    private readonly ILogger<UniquenessValidationSucceededEvent> _logger;
    private readonly IBackgroundJobClient _backgroundJobClient;

    public UniquenessValidationFailedEventHandler(
        ILogger<UniquenessValidationSucceededEvent> logger,
        IBackgroundJobClient backgroundJobClient)
    {
        _logger = logger;
        _backgroundJobClient = backgroundJobClient;
    }

    public Task Handle(UniquenessValidationFailedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("@{BatchFile} failed uniqueness validation", notification);

        return Task.CompletedTask;
    }
}