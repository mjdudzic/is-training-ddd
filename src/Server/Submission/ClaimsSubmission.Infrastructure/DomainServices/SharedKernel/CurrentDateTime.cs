using ClaimsSubmission.Domain.SharedKernel;

namespace ClaimsSubmission.Infrastructure.DomainServices.SharedKernel
{
	public class CurrentDateTime : ICurrentDateTime
	{
		public DateTime UtcNow => DateTime.UtcNow;
	}
}