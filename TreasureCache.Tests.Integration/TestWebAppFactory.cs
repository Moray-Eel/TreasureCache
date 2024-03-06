using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Presentation;

namespace TreasureCache.Tests.Integration;

public abstract class TestWebAppFactory : WebApplicationFactory<IPresentationMarker>
{
    protected readonly PostgreSqlContainer _psotgreSqlContainer = new PostgreSqlBuilder()
        .WithImage("postgres:latest")
        .WithDatabase("treasurecache.db")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .WithCleanUp(true)
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var service = services.SingleOrDefault(s =>
                s.ServiceType == typeof(DbContextOptions<ApplicationContext>));
            
            if(service is not null)
                services.Remove(service);
            
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(_psotgreSqlContainer.GetConnectionString());
            });
        });
        
        base.ConfigureWebHost(builder);
    }
}