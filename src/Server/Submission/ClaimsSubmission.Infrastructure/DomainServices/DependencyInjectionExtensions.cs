using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.ValidationRules;
using ClaimsSubmission.Domain.SharedKernel;
using ClaimsSubmission.Infrastructure.DomainServices.BatchFileAggregate;
using ClaimsSubmission.Infrastructure.DomainServices.Common;
using ClaimsSubmission.Infrastructure.DomainServices.SharedKernel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClaimsSubmission.Infrastructure.DomainServices;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICurrentUser, CurrentUser>();
        services.AddScoped<ICurrentDateTime, CurrentDateTime>();

        services.AddTransient<IBatchFileValidationRule, FileExistsRule>();
        services.AddTransient<IBatchFileValidationService, BatchFileValidationService>();
        services.AddTransient<IFileStorageService, FileStorageService>();
        services.AddTransient<IRepository, BatchFileWriteRepository>();
        services.AddTransient(typeof(IAggregateReadRepository<>), typeof(AggregateReadRepository<>));
        services.AddTransient<IBatchFileDuplicateCheck, BatchFileDuplicateCheck>();

        return services;
    }
}