namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;

public record ClaimCodeVerificationResult(string ClaimId, string Code, string Comment);