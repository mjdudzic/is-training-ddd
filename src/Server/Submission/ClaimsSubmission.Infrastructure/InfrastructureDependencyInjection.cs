using ClaimsSubmission.Infrastructure.ApplicationServices;
using ClaimsSubmission.Infrastructure.Configuration;
using ClaimsSubmission.Infrastructure.DomainServices;
using ClaimsSubmission.Infrastructure.Hangfire;
using ClaimsSubmission.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClaimsSubmission.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddClaimsSubmissionInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddHttpContextAccessor()
            .AddDatabase(configuration)
            .AddClaimsSubmissionConfiguration(configuration)
            .AddHangfire(configuration)
            .AddApplicationServices(configuration)
            .AddDomainServices(configuration);

        return services;
    }

    public static IApplicationBuilder UseClaimsSubmissionInfrastructure(this IApplicationBuilder application)
    {
        return application
            .UseHangfire();
    }
}