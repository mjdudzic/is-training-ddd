using Ardalis.Specification;

namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Specifications;

public sealed class BatchFileByIdSpec : Specification<BatchFile>
{
	public BatchFileByIdSpec(BatchFileId batchFileId)
	{
		Query
		   .Where(batch => batch.Id == batchFileId);
	}
}
