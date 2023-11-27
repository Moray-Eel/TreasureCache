using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreasureCache.Core.Interfaces.Repositories;
using TreasureCache.Infrastructure.Authentication;
using TreasureCache.Infrastructure.Authentication.Models;
using TreasureCache.Infrastructure.Persistence;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Infrastructure.Persistence.Repositories;

namespace TreasureCache.Infrastructure;

public static class InfrastructureInstaller
{
    public static IServiceCollection InstallInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddIdentity(configuration);
        services.AddTransient<IProductRepository, ProductRepository>();
        
        return services;
    }
}