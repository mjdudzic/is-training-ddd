using Microsoft.AspNetCore.Http;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.Commands.UploadBatchFile;

public record UploadBatchFileDto(string HealthcareFacilityId, IFormFile File);