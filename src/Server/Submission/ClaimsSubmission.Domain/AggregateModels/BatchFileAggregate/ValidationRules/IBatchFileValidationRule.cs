namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.ValidationRules;

public interface IBatchFileValidationRule
{
    int Order { get; }
    Task<RuleValidationResult> IsValid(BatchFile batchFile);
}