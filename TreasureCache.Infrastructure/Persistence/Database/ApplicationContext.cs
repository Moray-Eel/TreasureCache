using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TreasureCache.Core.Entities;
using TreasureCache.Infrastructure.Authentication.Models;

namespace TreasureCache.Infrastructure.Persistence.Database;

//IdentityDbContext<ApplicationUser> does not work with cutom role class
public class ApplicationContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
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
        SeedAdmin(builder);
    }

    private void SeedAdmin(ModelBuilder builder)
    {
        var address = new Address()
        {
            Id = 1000,
            City = "admin",
            Country = "admin",
            Street = "admin",
            ApartmentNumber = "admin",
            BuildingNumber = "admin",
            ZipCode = "admin",
        };
        
        var domainUser = new DomainUser
        {
            Id = Guid.NewGuid(),
            FirstName = "admin",
            LastName = "admin",
            PersonalDiscount = 0,
            SignedForNewsletter = false,
            AddressId = address.Id, 
        };
        
        var admin = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            LockoutEnabled = false,
            UserId = domainUser.Id,
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
        };
        
        PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();  
        admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin123..");
        
        builder.Entity<Address>().HasData(address);
        builder.Entity<DomainUser>().HasData(domainUser);
        builder.Entity<ApplicationUser>().HasData(admin);
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
        {
            RoleId = 1.ToString(),
            UserId = admin.Id
        });
    }
}