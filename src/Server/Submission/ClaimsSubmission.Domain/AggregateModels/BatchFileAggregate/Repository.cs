namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;

public interface IRepository
{
    void Add(BatchFile batchFile);
    ValueTask<BatchFile?> Get(BatchFileId batchFileId);
    Task SaveChanges(CancellationToken cancellationToken);
}