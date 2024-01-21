using TreasureCache.Infrastructure.Authentication.Models;

namespace TreasureCache.Infrastructure.Persistence.Repositories;

public interface IUserRepository
{
    public Task<ApplicationUser> GetById(string id, CancellationToken cancellationToken = default);
    public Task Update(ApplicationUser user, CancellationToken cancellationToken = default);
}