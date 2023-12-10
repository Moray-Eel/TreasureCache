using TreasureCache.Core.Entities;

namespace TreasureCache.Core.Interfaces.Repositories;

public interface IProductRepository
{
    public Task Add(Product product);
    public Task<Product> GetById(int id);
    public  Task Remove(Product product);
    public  Task Update(Product product);
}