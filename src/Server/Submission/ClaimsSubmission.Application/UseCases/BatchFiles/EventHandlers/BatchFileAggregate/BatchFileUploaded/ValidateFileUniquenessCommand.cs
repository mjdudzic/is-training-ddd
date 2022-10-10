using ClaimsSubmission.Application.UseCases.Common;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.EventHandlers.BatchFileAggregate.BatchFileUploaded;

public class ValidateFileUniquenessCommand : JobCommandBase
{
    public BatchFileId BatchFileId { get; init; }
}