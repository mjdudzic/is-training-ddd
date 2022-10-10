using ClaimsVetting.Domain.SeedWork;
using ClaimsVetting.Domain.SharedKernel;

namespace ClaimsVetting.Domain.AggregateModels.ClaimAggregate;

internal class MedicineCorrection : Entity<int>
{
    public string OriginalCode { get; set; }
    public string NewCode { get; set; }
    public Price OriginalTotalPrice { get; set; }
    public Price NewTotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
}