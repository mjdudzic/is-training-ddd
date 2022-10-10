using ClaimsAutoProcessing.Infrastructure.Hangfire;
using ClaimsAutoProcessing.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClaimsAutoProcessing.Infrastructure;

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