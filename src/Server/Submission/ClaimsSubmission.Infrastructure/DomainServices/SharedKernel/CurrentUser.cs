using ClaimsSubmission.Domain.SharedKernel;

namespace ClaimsSubmission.Infrastructure.DomainServices.SharedKernel
{
	public class CurrentUser : ICurrentUser
    {
        public string UserName => "Test user name";
        public string UserId => "Test User Id";
    }
}
