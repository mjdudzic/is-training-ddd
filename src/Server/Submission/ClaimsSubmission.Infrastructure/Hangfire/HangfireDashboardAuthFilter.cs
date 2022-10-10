using Hangfire.Dashboard;

namespace ClaimsSubmission.Infrastructure.Hangfire;

public class HangfireDashboardAuthFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context) => true;
}