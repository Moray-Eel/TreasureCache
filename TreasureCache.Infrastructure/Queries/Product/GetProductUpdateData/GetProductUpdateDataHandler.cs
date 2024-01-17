using Microsoft.EntityFrameworkCore;
using TreasureCache.Abstractions.Mediator.Interfaces.Queries.Handlers;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Infrastructure.Queries.Category.Mappers;
using TreasureCache.Infrastructure.Queries.Product.Mappers;

namespace TreasureCache.Infrastructure.Queries.Product.GetProductUpdateData;

public class GetProductUpdateDataHandler : IQueryHandler<GetProductUpdateDataQuery, ProductUpdateResponse>
{
    private readonly ApplicationContext _context;
    public GetProductUpdateDataHandler(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<ProductUpdateResponse> HandleAsync(GetProductUpdateDataQuery query, CancellationToken cancellationToken = default)
    {
        var product = await _context
            .Products
            .Include(p => p.ProductFiles)
            .FirstOrDefaultAsync(q => q.Id == query.Id, cancellationToken: cancellationToken);

        var productDto = product?.ProjectToDto() ?? throw new NullReferenceException();
        
        var categories = await _context.Categories
            .ProjectToDto()
            .ToListAsync(cancellationToken);
        
        return new ProductUpdateResponse(productDto, categories);
    }
}
