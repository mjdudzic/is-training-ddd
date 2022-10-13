using ClaimsAutoProcessing.Api.Domain;

namespace ClaimsAutoProcessing.Api.Application.Services;

public class InsuranceValidationService : IInsuranceValidationService
{
    public Task<InsuranceValidationResult> IsValid(BatchClaim claim)
    {
        return Task.FromResult(
            new InsuranceValidationResult(claim.Id, claim.PatientInsuranceNumber.StartsWith("x") == false));
    }
}