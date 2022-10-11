using ClaimsVetting.Domain.SeedWork;
using MediatR;

namespace ClaimsVetting.Domain.AggregateModels.ClaimAggregate;

internal class DiagnosisCorrection : Entity<int>
{
    public string OriginalCode { get; set; }
    public string NewCode { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public override void ApplyEvent(INotification @event)
    {
    }
}