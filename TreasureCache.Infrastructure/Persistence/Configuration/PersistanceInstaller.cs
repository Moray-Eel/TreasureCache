using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreasureCache.Infrastructure.Authentication.Configuration;
using TreasureCache.Infrastructure.Persistence.Database;

namespace TreasureCache.Infrastructure.Persistence.Configuration;

public static class PersistenceInstaller
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration
            .GetConnectionString("DefaultConnection");
        
        services.AddEntityFrameworkNpgsql()
            .AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseNpgsql(connectionString);
            });
        
        return services;
    }
}