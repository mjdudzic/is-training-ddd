using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.EventHandlers.BatchFileAggregate.FeedbackGenerated;

public class FeedbackGeneratedEventHandler : INotificationHandler<FeedbackGeneratedEvent>
{
    private readonly ILogger<FeedbackGeneratedEventHandler> _logger;

    public FeedbackGeneratedEventHandler(
        ILogger<FeedbackGeneratedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(FeedbackGeneratedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Feedback generated for @{BatchFile}", notification);

        return Task.CompletedTask;
    }
}