using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreasureCache.Infrastructure.Authentication.Models;
using TreasureCache.Infrastructure.Persistence.Database;

namespace TreasureCache.Infrastructure.Authentication;

public static class IdentityInstaller
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDefaultIdentity<ApplicationUser>(opt => opt.SignIn.RequireConfirmedAccount = true)
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationContext>();
            
        return services;
    }

}