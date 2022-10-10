using ClaimsAutoProcessing.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClaimsAutoProcessing.Infrastructure.Persistence;

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