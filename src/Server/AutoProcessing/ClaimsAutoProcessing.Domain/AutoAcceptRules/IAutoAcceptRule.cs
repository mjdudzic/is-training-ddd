namespace ClaimsAutoProcessing.Domain.AutoAcceptRules;

public interface IAutoAcceptRule
{
    Task<bool> Check(BatchClaim batchClaim);
}