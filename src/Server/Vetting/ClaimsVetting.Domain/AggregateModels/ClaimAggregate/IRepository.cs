namespace ClaimsVetting.Domain.AggregateModels.ClaimAggregate;

public interface IRepository
{
    Task<Claim> GetClaim(ClaimId id);

    Task Commit();
}