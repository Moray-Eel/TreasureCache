using TreasureCache.Core.Entities;
using TreasureCache.Core.Interfaces.Repositories;
using TreasureCache.Infrastructure.Persistence.Database;

namespace TreasureCache.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationContext _context;
    public ProductRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task Add(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }
}