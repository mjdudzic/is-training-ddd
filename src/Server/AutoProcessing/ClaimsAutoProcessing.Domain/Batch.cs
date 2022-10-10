namespace ClaimsAutoProcessing.Domain
{
    public class Batch
    {
        public int Id { get; set; }
        public string HealthcareFacilityCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public IReadOnlyCollection<BatchClaim> Claims { get; set; }
    }
}