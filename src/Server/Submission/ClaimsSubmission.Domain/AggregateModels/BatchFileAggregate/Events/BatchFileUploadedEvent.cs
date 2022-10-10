using MediatR;

namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Events;

public record BatchFileUploadedEvent(BatchFileId Id, string FilePath) : INotification;