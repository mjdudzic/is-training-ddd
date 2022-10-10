using Microsoft.EntityFrameworkCore;

namespace ClaimsAutoProcessing.Api.Infrastructure.Persistence;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:DefaultConnection"];

        services.AddDbContext<ClaimsAutoProcessingContext>(options =>
        {
            options.EnableDetailedErrors();
            options.UseSqlite(connectionString);
        });

        return services;
    }
}