using TreasureCache.Core.Entities;

namespace TreasureCache.Core.Interfaces.Repositories;

public interface IProductRepository
{
    public Task Add(Product product);
}