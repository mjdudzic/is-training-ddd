using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.ValidationRules;

namespace ClaimsSubmission.Infrastructure.DomainServices.BatchFileAggregate;

public class BatchFileValidationService : IBatchFileValidationService
{
    public IReadOnlyCollection<IBatchFileValidationRule> AppliedValidationRules { get; }

    public BatchFileValidationService(IEnumerable<IBatchFileValidationRule> validationRules)
    {
        AppliedValidationRules = validationRules.ToList();
    }
    
    public async Task<RuleValidationResult> IsValid(BatchFile batchFile)
    {
        foreach (var rule in AppliedValidationRules)
        {
            var ruleResult = await rule.IsValid(batchFile);
            if (ruleResult.Success == false)
                return ruleResult;
        }

        return new RuleValidationResult(true, string.Empty);
    }
}