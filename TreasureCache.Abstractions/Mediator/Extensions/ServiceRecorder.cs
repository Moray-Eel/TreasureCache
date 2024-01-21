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
        
        //Filtering out open generics ex: IQueryHandler<T, TResponse>, IQueryHandler<int, TResponse>
        config.RegisteredAssemblies
            .SelectMany(a => a.DefinedTypes)
            .Where(t => !t.IsAnOpenGenericType())
            .ToList()
            .ForEach(t =>
            {
                //Checking if the type implements the requestInterface 
                var implementedInterfaces = t.GetImplementedInterfacesMatching(requestInterface)
                    .ToList();
                
                //Skip if the type does not implement the requestInterface
                if(!implementedInterfaces.Any())
                    return;
                
                // Collect the handler types and interfaces
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
            //Getting the handlers for each saved interface
            var matchingHandlers = handlers.Where(i.IsAssignableFrom)
                .ToList();
            
            //Checking for duplicate handlers
            if(matchingHandlers.Count > 1)
                throw new InvalidOperationException($"Multiple handlers found for {i.Name}. Only one handler per request is allowed.");

            //Registering the handler in Dependency injection
            matchingHandlers.ForEach(h =>
            {
                services.AddTransient(i, h);
            });

        });
    }

    private static IEnumerable<Type> GetImplementedInterfacesMatching(this Type analysedType, Type interfaceType)
    {
        _ = analysedType ?? throw new ArgumentNullException(nameof(analysedType));

        //Sieving the types that are not concrete
        if (analysedType is not {IsInterface: false, IsAbstract: false})
            return Enumerable.Empty<Type>();

        if (interfaceType.IsInterface)
        {
            // Check if the type analysedType implements the provided interfaceType parameter
            return analysedType.GetInterfaces().Where(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType);
        }
        
        return Enumerable.Empty<Type>();
    }
        
    //Checking if the type is an open generic type. Ex. IGeneric<,>, IGeneric<int, T>, IGeneric<T>
    private static bool IsAnOpenGenericType(this Type type)
     => type.IsGenericTypeDefinition || type.ContainsGenericParameters;
}