using Microsoft.Extensions.DependencyInjection;
using TreasureCache.Abstractions.Mediator.Interfaces;

namespace TreasureCache.Abstractions.Mediator.Extensions;

public static class MediatorExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services,
        Action<MediatorAssemblyConfigurator> config)
    {
        var mediatorConfig = new MediatorAssemblyConfigurator();

        //Accepting and applying configuration
        config(mediatorConfig);
        
        if(!mediatorConfig.RegisteredAssemblies.Any())
            throw new ArgumentException("No assemblies found to scan. Provide at least one assembly");

        //Capturing handlers
        services.CaptureHandlers(mediatorConfig);
        services.AddTransient<IMediator, Mediator>();
        
        return services;
    }
}