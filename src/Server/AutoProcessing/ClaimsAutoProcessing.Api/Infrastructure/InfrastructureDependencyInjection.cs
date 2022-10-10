using ClaimsAutoProcessing.Api.Infrastructure.Hangfire;
using ClaimsAutoProcessing.Api.Infrastructure.Persistence;

namespace ClaimsAutoProcessing.Api.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddClaimsAutoProcessingInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddHttpContextAccessor()
            .AddDatabase(configuration)
            .AddHangfire(configuration);

        return services;
    }

    public static IApplicationBuilder UseClaimsAutoProcessingInfrastructure(this IApplicationBuilder application)
    {
        return application
            .UseHangfire();
    }
}