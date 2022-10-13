namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.ValidationRules;

public class IsJsonFile : IBatchFileValidationRule
{
    public int Order { get; }
    public Task<RuleValidationResult> IsValid(BatchFile batchFile)
    {
        return Task.FromResult(new RuleValidationResult(true, null));
    }
}