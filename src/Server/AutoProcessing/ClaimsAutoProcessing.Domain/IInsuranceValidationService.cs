namespace ClaimsAutoProcessing.Domain;

public interface IInsuranceValidationService
{
    Task<InsuranceValidationResult> IsValid(BatchClaim claim);
}