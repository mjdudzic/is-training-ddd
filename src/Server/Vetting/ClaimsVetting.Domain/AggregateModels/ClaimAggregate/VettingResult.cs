using Ardalis.SmartEnum;

namespace ClaimsVetting.Domain.AggregateModels.ClaimAggregate;

public sealed class VettingResult : SmartEnum<VettingResult>
{
    public static readonly VettingResult None = new(nameof(None), 0);
    public static readonly VettingResult Accepted = new(nameof(Accepted), 1);
    public static readonly VettingResult Rejected = new(nameof(Rejected), 2);

    public VettingResult(string name, int value) : base(name, value)
    {
    }
}