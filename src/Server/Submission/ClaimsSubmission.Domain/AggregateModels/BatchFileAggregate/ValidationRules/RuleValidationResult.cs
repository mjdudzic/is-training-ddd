namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.ValidationRules;

public record RuleValidationResult(bool Success, string? FailReason);