namespace ClaimsVetting.Domain.AggregateModels.ClaimAggregate;

public class ClaimAggregateException : Exception
{
    public ClaimAggregateException(string message) : base(message)
    {
    }
}