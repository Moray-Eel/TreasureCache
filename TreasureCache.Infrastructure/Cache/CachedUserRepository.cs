using Microsoft.Extensions.Caching.Memory;
using TreasureCache.Infrastructure.Authentication.Models;
using TreasureCache.Infrastructure.Persistence.Repositories;

namespace TreasureCache.Infrastructure.Cache;

public class CachedUserRepository : IUserRepository
{
    private readonly UserRepository _repository;
    private readonly IMemoryCache _cache;

    public CachedUserRepository(UserRepository repository, IMemoryCache cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<ApplicationUser> GetById(string id, CancellationToken cancellationToken = default)
        => await _cache.GetOrCreateAsync(id, entry => _repository
            .GetById(id, cancellationToken));
    

    public async Task Update(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        await _repository
            .Update(user, cancellationToken);

        _cache.Set(user.Id, user);
    }
}