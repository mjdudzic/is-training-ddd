namespace ClaimsSubmission.Domain.SeedWork
{
	public abstract class AggregateRoot<T> : Entity<T>, IAggregateRoot
	    where T: class
	{
	}

	public interface IAggregateRoot
	{
	}
}
