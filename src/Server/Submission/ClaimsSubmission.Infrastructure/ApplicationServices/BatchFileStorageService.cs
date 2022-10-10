using ClaimsSubmission.Application.UseCases.BatchFiles.Services;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using ClaimsSubmission.Infrastructure.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace ClaimsSubmission.Infrastructure.ApplicationServices;

public class BatchFileStorageService : IBatchFileStorageService
{
    private readonly IOptions<BatchFileStorageConfiguration> _config;

    public BatchFileStorageService(IOptions<BatchFileStorageConfiguration> config)
    {
        _config = config;
    }

    public async Task<BatchFileInfo> SaveFile(HealthcareFacilityId healthcareFacilityId, IFormFile file)
    {
        var storagePath = Path.Combine(_config.Value.RootPath, healthcareFacilityId.AccreditationCode);

        if (!Directory.Exists(storagePath))
            Directory.CreateDirectory(storagePath);

        var filePath = Path.Combine(storagePath,
            $"batchFile_{healthcareFacilityId.AccreditationCode}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}");

        await using var fileStream = File.Create(filePath);
        await file.CopyToAsync(fileStream);

        return new BatchFileInfo(filePath, file.FileName);
    }
}