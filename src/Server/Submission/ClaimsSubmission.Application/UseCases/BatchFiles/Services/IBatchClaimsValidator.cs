using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.Services;

public interface IBatchClaimsValidator
{
    Task<BatchClaimsVerificationResult> ValidateCodes(string relativeFilePath, CancellationToken cancellationToken);
}