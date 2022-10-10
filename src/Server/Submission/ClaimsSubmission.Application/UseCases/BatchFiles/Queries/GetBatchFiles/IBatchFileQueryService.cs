namespace ClaimsSubmission.Application.UseCases.BatchFiles.Queries.GetBatchFiles;

public interface IBatchFileQueryService
{
    Task<IEnumerable<BatchFileDto>> GetBatchFiles();
}