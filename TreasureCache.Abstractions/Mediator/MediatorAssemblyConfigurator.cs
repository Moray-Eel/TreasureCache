using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace TreasureCache.Abstractions.Mediator;

public class MediatorAssemblyConfigurator
{
    public Type DefaultImplementationType = typeof(Mediator);
    public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Transient;
    private Assembly[] _registeredAssemblies;

    public Assembly[] RegisteredAssemblies
    {
        get => _registeredAssemblies ?? throw new ArgumentNullException();
        set =>
            _registeredAssemblies = _registeredAssemblies is null
                ? value
                : throw new InvalidOperationException("RegisteredAssemblies can only be set once.");
    }

    public void RegisterFromAssembliesContainingMarkers(Type[] markers)
    {
        RegisteredAssemblies = markers.Distinct()
            .Select(m => m.Assembly)
            .ToArray();
    }
}