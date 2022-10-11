using ClaimsVetting.Domain.AggregateModels.ClaimAggregate;
using MediatR;

namespace ClaimsVetting.Tests.Domain.EventSourcing;

public class Repository : IRepository
{
    private readonly Dictionary<ClaimId, IList<INotification>> _inMemoryStream = new();

    public Task<Claim> GetClaim(ClaimId id)
    {
        var claim = new Claim(id);

        if (_inMemoryStream.ContainsKey(id))
        {
            foreach (var @event in _inMemoryStream[id])
            {
                claim.AddDomainEvent(@event);
            }
        }

        return Task.FromResult(claim);
    }

    public Task Commit()
    {
        throw new NotImplementedException();
    }

    public void Save(Claim claim)
    {
        _inMemoryStream[claim.Id] = claim.Events.ToList();
    }
}