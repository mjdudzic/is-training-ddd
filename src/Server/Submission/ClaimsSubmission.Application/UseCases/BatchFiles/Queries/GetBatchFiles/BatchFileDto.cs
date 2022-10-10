namespace ClaimsSubmission.Application.UseCases.BatchFiles.Queries.GetBatchFiles;

public class BatchFileDto
{
    public string Id { get; set; }
    public string HealthcareFacilityId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? SubmittedAt { get; set; }
    public string FileOriginalName { get; set; }
    public bool IsSubmittable { get; set; }
    public string? DuplicatedBatchFileId { get; set; }
    public string? ReportsUri { get; set; }
    public int ClaimsTotalCount { get; set; }
    public int ClaimsValidCount { get; set; }
    public decimal ValidClaimsRatio => ClaimsTotalCount == 0
        ? 0
        : (decimal)ClaimsValidCount / ClaimsTotalCount;
}