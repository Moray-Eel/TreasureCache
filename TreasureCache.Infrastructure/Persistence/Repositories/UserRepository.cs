using Microsoft.EntityFrameworkCore;
using TreasureCache.Infrastructure.Authentication.Models;
using TreasureCache.Infrastructure.Persistence.Database;

namespace TreasureCache.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<ApplicationUser> GetById(string id,
        CancellationToken cancellationToken = default)
        => await _context.Users
            .Include(u => u.User)
            .ThenInclude(u => u.Address)
            .AsNoTracking()
            .FirstAsync(u => u.Id == id, cancellationToken);

    public async Task Update(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
    }
}