using MediatR;

namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Events;

public record UniquenessValidationFailedEvent(BatchFileId Id) : INotification;