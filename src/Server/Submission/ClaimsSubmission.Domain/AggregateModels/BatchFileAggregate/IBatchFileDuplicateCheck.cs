namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;

public interface IBatchFileDuplicateCheck
{
    Task<BatchFileId?> IsDuplicate(BatchFile batchFile);
}