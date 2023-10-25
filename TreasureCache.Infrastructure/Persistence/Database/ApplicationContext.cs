using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TreasureCache.Core.Entities;
using TreasureCache.Infrastructure.Authentication.Models;

namespace TreasureCache.Infrastructure.Persistence.Database;

public class ApplicationContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<DomainUser> DomainUsers { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Cart> Carts { get; set; } = null!;
    public DbSet<CartItem> CartItems { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<ContactForm> ContactForms { get; set; } = null!;
    public DbSet<Currency> Currencies { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductFiles> ProductFiles { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfigurationsFromAssembly(typeof(IInfrastructureMarker).Assembly);
    }
}