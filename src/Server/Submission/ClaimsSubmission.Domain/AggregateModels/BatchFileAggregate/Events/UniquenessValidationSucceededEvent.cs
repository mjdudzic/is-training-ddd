using MediatR;

namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Events;

public record UniquenessValidationSucceededEvent(BatchFileId Id) : INotification;