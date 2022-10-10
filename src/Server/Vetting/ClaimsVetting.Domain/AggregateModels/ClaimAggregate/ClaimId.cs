namespace ClaimsVetting.Domain.AggregateModels.ClaimAggregate;

public record ClaimId
{
    public Guid Value { get; }

    public ClaimId(Guid value)
    {
        Value = value;
    }

    public static implicit operator Guid(ClaimId id)
        => id.Value;

    public static implicit operator ClaimId(Guid id)
        => new(id);
}