using Microsoft.EntityFrameworkCore;
using TreasureCache.Abstractions.Mediator.Interfaces.Queries.Handlers;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Infrastructure.Queries.Product.Mappers;

namespace TreasureCache.Infrastructure.Queries.Product.GetProduct;

public class GetProductHandler : IQueryHandler<GetProductQuery, ProductResponse>
{
    private readonly ApplicationContext _context;
    public GetProductHandler(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<ProductResponse> HandleAsync(GetProductQuery query, CancellationToken cancellationToken = default)
    {
        var product = await _context
            .Products
            .Include(p => p.ProductFiles)
            .FirstOrDefaultAsync(q => q.Id == query.Id, cancellationToken: cancellationToken);

        var productDto = product?.ProjectToDto() ?? throw new NullReferenceException();
        
        return new ProductResponse(productDto);
    }
}
