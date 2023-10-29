using Microsoft.Extensions.DependencyInjection;
using TreasureCache.Abstractions.Mediator.Interfaces.Commands.Handlers;
using TreasureCache.Abstractions.Mediator.Interfaces.Queries.Handlers;

namespace TreasureCache.Abstractions.Mediator.Extensions;

public static class ServiceRecorder
{
    public static void CaptureHandlers(this IServiceCollection services,
        MediatorAssemblyConfigurator config)
    {
        MatchHandlers(typeof(IQueryHandler<,>), services, config);
        MatchHandlers(typeof(IQueryHandler<>), services, config);
        MatchHandlers(typeof(ICommandHandler<,>), services, config);
        MatchHandlers(typeof(ICommandHandler<>), services, config);
    }

    private static void MatchHandlers(Type requestInterface, IServiceCollection services, MediatorAssemblyConfigurator config)
    {
        var handlers = new List<Type>();
        var interfaces = new List<Type>();
        
        config.RegisteredAssemblies
            .SelectMany(a => a.DefinedTypes)
            .Where(t => !t.IsAnOpenGenericType())
            .ToList()
            .ForEach(t =>
            {
                var implementedInterfaces = t.GetInterfacesImplemented(requestInterface)
                    .ToList();
                
                if(!implementedInterfaces.Any())
                    return;
                
                handlers.Add(t);
                implementedInterfaces.ForEach(i =>
                {
                    if (interfaces.Contains(i))
                        return;
                    interfaces.Add(i);
                });
            });
        
        interfaces.ForEach(i =>
        {
            var matchingHandlers = handlers.Where(i.IsAssignableFrom)
                .ToList();
            
            if(matchingHandlers.Count > 1)
                throw new InvalidOperationException($"Multiple handlers found for {i.Name}. Only one handler per request is allowed.");

            matchingHandlers.ForEach(h =>
            {
                services.AddTransient(i, h);
            });

        });
    }

    private static IEnumerable<Type> GetInterfacesImplemented(this Type analysedType, Type interfaceType)
    {
        _ = analysedType ?? throw new ArgumentNullException(nameof(analysedType));

        if (analysedType is not {IsInterface: false, IsAbstract: false})
            return Enumerable.Empty<Type>();

        if (interfaceType.IsInterface)
        {
            return analysedType.GetInterfaces().Where(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType);
        }
        
        return Enumerable.Empty<Type>();
    }
        
    
    private static bool IsAnOpenGenericType(this Type type)
     => type.IsGenericTypeDefinition || type.ContainsGenericParameters;
}