using Hangfire.Dashboard;

namespace ClaimsAutoProcessing.Api.Infrastructure.Hangfire;

public class HangfireDashboardAuthFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context) => true;
}