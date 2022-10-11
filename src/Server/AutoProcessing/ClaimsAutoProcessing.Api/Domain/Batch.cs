using ClaimsAutoProcessing.Api.Domain.SeedWork;

namespace ClaimsAutoProcessing.Api.Domain
{
    public class Batch : AggregateRoot<int>
    {
        public string HealthcareFacilityCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool AutoProcessingCompleted { get; set; }
        public IReadOnlyCollection<BatchClaim> Claims { get; set; }
    }
}