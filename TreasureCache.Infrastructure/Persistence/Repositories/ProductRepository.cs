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

    public async Task Add(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products
            .AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Product> GetById(int id, CancellationToken cancellationToken = default)
        => await _context.Products.Include(p => p.ProductFiles)
            .FirstAsync(p => p.Id == id, cancellationToken);

    public async Task Remove(Product product, CancellationToken cancellationToken = default)
    {
        _context.Products
            .Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Product product, CancellationToken cancellationToken = default)
    {
        _context.Products
            .Update(product);
        await _context.SaveChangesAsync(cancellationToken);
    }
}