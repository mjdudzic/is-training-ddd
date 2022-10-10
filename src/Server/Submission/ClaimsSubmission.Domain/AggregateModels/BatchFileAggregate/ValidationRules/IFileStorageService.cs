namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.ValidationRules;

public interface IFileStorageService
{
    Task<bool> FileExists(string fileRelativePath);
    Task<bool> FileIsValidJson(string fileRelativePath);
}