using System.Reflection;
using ClaimsAutoProcessing.Api.Application.Services;
using ClaimsAutoProcessing.Api.Application.Services.AutoAcceptRules;
using MediatR;

namespace ClaimsAutoProcessing.Api.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddClaimsAutoProcessingApplication(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddTransient<InsuranceValidationService>()
            .AddTransient<TariffsCorrectionService>()
            .AddTransient<IAutoAcceptRule, ClaimNotExpensiveRule>()
            .AddTransient<IAutoAcceptRule, AntenatalDiagnosisMeetsPriceRangeRule>();

}