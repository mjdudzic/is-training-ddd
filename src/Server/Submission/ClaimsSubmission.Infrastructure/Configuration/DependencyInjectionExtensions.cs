using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClaimsSubmission.Infrastructure.Configuration;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddClaimsSubmissionConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<BatchFileStorageConfiguration>(configuration.GetSection("Infrastructure:BatchFileStorage"));

        return services;
    }
}