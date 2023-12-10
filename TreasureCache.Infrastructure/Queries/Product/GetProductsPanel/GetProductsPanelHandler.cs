using TreasureCache.Abstractions.Mediator.Interfaces.Queries.Handlers;
using TreasureCache.Abstractions.Paging;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Infrastructure.Queries.Product.Dtos;
using TreasureCache.Infrastructure.Queries.Product.Mappers;

namespace TreasureCache.Infrastructure.Queries.Product.GetProductsPanel;

public class GetProductsPanelHandler : IQueryHandler<GetProductsPanelQuery, ProductsPanelResponse>
{
    private readonly ApplicationContext _context;
    public GetProductsPanelHandler(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<ProductsPanelResponse> HandleAsync(GetProductsPanelQuery command, CancellationToken cancellationToken = default)
    {
        var products = _context
            .Products
            .ProjectToDto();
        
        var pagedProducts = await PagedList<ProductWithCategoryDto>.ToPagedList(
            products, 
            command.Page, 
            command.PageSize,
            cancellationToken);
        
        return new ProductsPanelResponse(pagedProducts);
    }
}