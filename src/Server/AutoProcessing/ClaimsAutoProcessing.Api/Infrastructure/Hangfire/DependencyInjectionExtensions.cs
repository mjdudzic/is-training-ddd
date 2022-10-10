﻿using Hangfire;
using Hangfire.Console;
using Hangfire.MemoryStorage;

namespace ClaimsAutoProcessing.Api.Infrastructure.Hangfire;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddHangfire(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseConsole()
            .UseMemoryStorage());
            //.UseSqlServerStorage(configuration["ConnectionStrings:Hangfire"]));

        services.AddHangfireServer();

        return services;
    }

    public static IApplicationBuilder UseHangfire(this IApplicationBuilder app)
        => app.UseHangfireDashboard("/dashboard", new DashboardOptions
        {
            Authorization = new[] { new HangfireDashboardAuthFilter() },
            IgnoreAntiforgeryToken = true
        });
}