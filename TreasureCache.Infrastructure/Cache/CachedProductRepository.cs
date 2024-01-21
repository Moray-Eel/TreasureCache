using Microsoft.Extensions.Caching.Memory;
using TreasureCache.Core.Entities;
using TreasureCache.Core.Interfaces.Repositories;
using TreasureCache.Infrastructure.Persistence.Repositories;

namespace TreasureCache.Infrastructure.Cache;

public class CachedProductRepository : IProductRepository
{
    private readonly ProductRepository _repository;
    private readonly IMemoryCache _cache;

    public CachedProductRepository(ProductRepository repository, IMemoryCache cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task Add(Product product, CancellationToken cancellationToken = default)
    {
        await _repository
            .Update(product, cancellationToken);

        _cache.Set(product.Id, product);
    }

    public async Task<Product> GetById(int id, CancellationToken cancellationToken = default)
        => await _cache.GetOrCreateAsync(id, entry => _repository
                .GetById(id, cancellationToken));
    

    public async Task Remove(Product product, CancellationToken cancellationToken = default)
    {
        await _repository
            .Remove(product, cancellationToken);

        _cache.Remove(product.Id);
    }

    public async Task Update(Product product, CancellationToken cancellationToken = default)
    {
        await _repository
            .Update(product, cancellationToken);

        _cache.Set(product.Id, product);
    }
}