namespace ClaimsAutoProcessing.Api.Domain.SeedWork
{
	public abstract class AggregateRoot<T> : Entity<T>, IAggregateRoot
    {
	}

	public interface IAggregateRoot
	{
	}
}
