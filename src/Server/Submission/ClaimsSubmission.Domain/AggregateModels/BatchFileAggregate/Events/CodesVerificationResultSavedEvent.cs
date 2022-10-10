using MediatR;

namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Events;

public record CodesVerificationResultSavedEvent(BatchFileId Id) : INotification;