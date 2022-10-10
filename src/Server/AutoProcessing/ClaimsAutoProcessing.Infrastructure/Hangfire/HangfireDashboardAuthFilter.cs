using Hangfire.Dashboard;

namespace ClaimsAutoProcessing.Infrastructure.Hangfire;

public class HangfireDashboardAuthFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context) => true;
}