using MediatR;

namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Events;

public record FeedbackGeneratedEvent(BatchFileId Id) : INotification;