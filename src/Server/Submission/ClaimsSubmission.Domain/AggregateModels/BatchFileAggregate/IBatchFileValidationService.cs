using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.ValidationRules;

namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;

public interface IBatchFileValidationService
{
    IReadOnlyCollection<IBatchFileValidationRule> AppliedValidationRules { get; }
    Task<RuleValidationResult> IsValid(BatchFile batchFile);
}