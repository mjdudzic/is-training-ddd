using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using Microsoft.AspNetCore.Http;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.Services;

public interface IBatchFileStorageService
{
    Task<BatchFileInfo> SaveFile(HealthcareFacilityId healthcareFacilityId, IFormFile file);
}