using Microsoft.EntityFrameworkCore;
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

    public async Task<Product> GetById(int id)
        => await _context.Products.FirstAsync(p => p.Id == id);
    
    public async Task Remove(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
}