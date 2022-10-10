using System.Text.Json;
using ClaimsSubmission.Domain.SeedWork;
using ClaimsSubmission.Domain.SharedKernel;

namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;

public class BatchFileValidationResult : Entity<BatchFileValidationResultId>
{
    private BatchFileId _batchFileId;
    private DateTime _createdAt;

    private string? _batchClaimsValidationResult;
    private int _claimsTotalCount;
    private int _claimsValidCount;

    public decimal ValidClaimsRatio => _claimsTotalCount == 0
        ? 0
        : (decimal)_claimsValidCount / _claimsTotalCount;

    internal BatchFileValidationResult() { }

    public BatchFileValidationResult(
        BatchFileId batchFileId,
        BatchClaimsVerificationResult batchClaimsVerificationResult,
        ICurrentDateTime currentDateTime)
    {
        _batchFileId = batchFileId;
        _createdAt = currentDateTime.UtcNow;
        _claimsTotalCount = batchClaimsVerificationResult.ClaimsTotalCount;
        _claimsValidCount = _claimsTotalCount - batchClaimsVerificationResult.ClaimCodeVerificationResults.Count;
        _batchClaimsValidationResult = JsonSerializer.Serialize(batchClaimsVerificationResult);

        Id = new BatchFileValidationResultId(Guid.NewGuid());
    }
}