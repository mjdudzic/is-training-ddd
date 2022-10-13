namespace ClaimsAutoProcessing.Api.Domain
{
    public class Batch
    {
        public int Id { get; set; }
        public string HealthcareFacilityCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool AutoProcessingCompleted { get; set; }

        //internal List<BatchClaim> _claims;
        public IReadOnlyCollection<BatchClaim> Claims { get; set; }

        public async Task ValidateInsurance(IInsuranceValidationService insuranceValidationService)
        {
            if (AutoProcessingCompleted)
                throw new BatchException("Already processed");

            var insuranceCheckTasks = Claims
                .Select(insuranceValidationService.IsValid)
                .ToList();

            var insuranceValidationResults = await Task.WhenAll(insuranceCheckTasks);

            Claims
                .Where(c =>
                    insuranceValidationResults
                        .Any(v => v.ClaimId == c.Id && v.InsuranceValid == false))
                .ToList()
                .ForEach(c => c.Invalidate());
        }

        public void SelectForAudit(double auditCountRatio)
        {
            var claimsToAuditCount = (int)(Claims.Count * auditCountRatio);

            var claimsToAudit = Claims
                .Where(c => c.VettingStatus == VettingStatus.Accepted)
                .OrderBy(_ => Guid.NewGuid())
                .Take(claimsToAuditCount == 0 ? 1 : claimsToAuditCount)
                .ToList();

            claimsToAudit.ForEach(c => c.SelectForAudit());
        }
    }
}