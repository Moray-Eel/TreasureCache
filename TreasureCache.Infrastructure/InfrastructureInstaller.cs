using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreasureCache.Infrastructure.Authentication;
using TreasureCache.Infrastructure.Authentication.Models;
using TreasureCache.Infrastructure.Persistence;
using TreasureCache.Infrastructure.Persistence.Database;

namespace TreasureCache.Infrastructure;

public static class InfrastructureInstaller
{
    public static IServiceCollection InstallInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddIdentity(configuration);
        
        return services;
    }
}