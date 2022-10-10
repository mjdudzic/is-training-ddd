using MediatR;
using Microsoft.Extensions.Logging;

namespace ClaimsSubmission.Application.UseCases.Common;

public class EventLogger : INotificationHandler<INotification>
{
    private readonly ILogger<EventLogger> _logger;

    public EventLogger(ILogger<EventLogger> logger)
    {
        _logger = logger;
    }

    public Task Handle(INotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Event: @{event}", notification);
        return Task.CompletedTask;
    }
}