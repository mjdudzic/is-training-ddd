using ClaimsSubmission.Application.UseCases.BatchFiles.Queries.GetBatchFiles;
using ClaimsSubmission.Application.UseCases.BatchFiles.Services;
using Eclaims.Submission.Application.UseCases.BatchFiles.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClaimsSubmission.Infrastructure.ApplicationServices;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IBatchFileStorageService, BatchFileStorageService>();
        services.AddTransient<IFileHashGenerator, FileHashGenerator>();
        services.AddTransient<IBatchClaimsValidator, BatchClaimsValidator>();
        services.AddTransient<IBatchFileQueryService, BatchFileQueryService>();

        return services;
    }
}