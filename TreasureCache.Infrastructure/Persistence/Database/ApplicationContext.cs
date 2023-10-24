using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TreasureCache.Infrastructure.Authentication.Models;

namespace TreasureCache.Infrastructure.Persistence.Database;

public class ApplicationContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }  
}