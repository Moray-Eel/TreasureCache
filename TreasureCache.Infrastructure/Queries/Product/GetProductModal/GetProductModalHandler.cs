using Microsoft.EntityFrameworkCore;
using TreasureCache.Abstractions.Mediator.Interfaces.Queries.Handlers;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Infrastructure.Queries.Category.Mappers;
using TreasureCache.Infrastructure.Queries.Product.Mappers;

namespace TreasureCache.Infrastructure.Queries.Product.GetProductModal;

public class GetProductModalHandler : IQueryHandler<GetProductModalQuery, ProductModalResponse>
{
    private readonly ApplicationContext _context;
    public GetProductModalHandler(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<ProductModalResponse> HandleAsync(GetProductModalQuery query, CancellationToken cancellationToken = default)
    {
        var product = await _context
            .Products
            .Include(p => p.ProductFiles)
            .FirstOrDefaultAsync(q => q.Id == query.Id, cancellationToken: cancellationToken);

        var productDto = product?.ProjectToDto() ?? throw new NullReferenceException();
        
        var categories = await _context.Categories
            .ProjectToDto()
            .ToListAsync(cancellationToken);
        
        return new ProductModalResponse(productDto, categories);
    }
}
