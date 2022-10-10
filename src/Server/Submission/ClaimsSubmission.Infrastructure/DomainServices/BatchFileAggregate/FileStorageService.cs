using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.ValidationRules;
using ClaimsSubmission.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace ClaimsSubmission.Infrastructure.DomainServices.BatchFileAggregate;

public class FileStorageService : IFileStorageService
{
    private readonly IOptions<BatchFileStorageConfiguration> _options;

    public FileStorageService(IOptions<BatchFileStorageConfiguration> options)
    {
        _options = options;
    }
    public Task<bool> FileExists(string fileRelativePath)
    {
        var filePath = Path.Combine(_options.Value.RootPath, fileRelativePath);
        return Task.FromResult(File.Exists(filePath));
    }

    public Task<bool> FileIsValidJson(string fileRelativePath)
    {
        throw new NotImplementedException();
    }
}