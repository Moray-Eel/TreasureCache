using TreasureCache.Core.Entities;

namespace TreasureCache.Core.Interfaces.Repositories;

public interface IProductRepository
{
    public Task Add(Product product, CancellationToken cancellationToken = default);
    public Task<Product> GetById(int id, CancellationToken cancellationToken = default);
    public Task Remove(Product product, CancellationToken cancellationToken = default);
    public Task Update(Product product, CancellationToken cancellationToken = default);
}