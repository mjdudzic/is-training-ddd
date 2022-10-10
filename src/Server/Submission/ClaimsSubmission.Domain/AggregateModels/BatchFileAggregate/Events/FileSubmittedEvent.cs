using MediatR;

namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Events;

public record FileSubmittedEvent(BatchFileId Id) : INotification;