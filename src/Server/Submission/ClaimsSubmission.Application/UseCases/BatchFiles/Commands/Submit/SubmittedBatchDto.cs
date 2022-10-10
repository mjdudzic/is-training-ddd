namespace ClaimsSubmission.Application.UseCases.BatchFiles.Commands.Submit;

public record SubmittedBatchDto(string HealthcareFacilityId, Guid BatchFileId, DateTime? SubmittedAt, string ReportsUri);