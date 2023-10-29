using Microsoft.Extensions.DependencyInjection;
using TreasureCache.Abstractions.Mediator.Interfaces;

namespace TreasureCache.Abstractions.Mediator.Extensions;

public static class MediatorExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services,
        Action<MediatorAssemblyConfigurator> config)
    {
        var mediatorConfig = new MediatorAssemblyConfigurator();

        config(mediatorConfig);
        
        if(!mediatorConfig.RegisteredAssemblies.Any())
            throw new ArgumentException("No assemblies found to scan. Provide at least one assembly");

        services.CaptureHandlers(mediatorConfig);
        services.AddTransient<IMediator, Abstractions.Mediator.Mediator>();
        
        return services;
    }
}