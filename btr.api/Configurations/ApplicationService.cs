using System.Reflection;
using btr.application;
using FluentValidation;
using Nuna.Lib.AutoNumberHelper;
using Nuna.Lib.CleanArchHelper;
using Nuna.Lib.ValidationHelper;
using Scrutor;

namespace btr.api.Configurations;

public static class ApplicationService
{
    private const string APPLICATION_ASSEMBLY = "btr.application";

    public static IServiceCollection AddApplication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyAnchor).Assembly));
        services.AddValidatorsFromAssembly(Assembly.Load(APPLICATION_ASSEMBLY));

        services.AddScoped<INunaCounterBL, NunaCounterBL>();
        services.AddScoped<DateTimeProvider, DateTimeProvider>();
        services
            .Scan(selector => selector
                .FromAssemblyOf<ApplicationAssemblyAnchor>()
                    .AddClasses(c => c.AssignableTo(typeof(INunaWriter<>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsSelfWithInterfaces()
                    .WithScopedLifetime()
                .FromAssemblyOf<ApplicationAssemblyAnchor>()
                    .AddClasses(c => c.AssignableTo(typeof(INunaBuilder<>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsSelfWithInterfaces()
                    .WithScopedLifetime());

        return services;
    }
}