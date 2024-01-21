using TreasureCache.Abstractions.Mediator.Interfaces.Queries.Handlers;
using TreasureCache.Abstractions.Paging;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Infrastructure.Queries.Products.Dtos;
using TreasureCache.Infrastructure.Queries.Products.Mappers;

namespace TreasureCache.Infrastructure.Queries.Products.GetProductCards;

public class GetProductCardsHandler : IQueryHandler<GetProductCardsQuery, ProductCardsResponse>
{
    private readonly ApplicationContext _context;

    public GetProductCardsHandler(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<ProductCardsResponse> HandleAsync(GetProductCardsQuery query,
        CancellationToken cancellationToken = default)
    {
        var productDtos = _context
            .Products
            .Where(p => p.IsActive)
            .ProjectToDto();

        var pagedProducts = await PagedList<ProductWithCategoryDto>
            .ToPagedList(productDtos, query.Page, query.PageSize, cancellationToken);

        return new ProductCardsResponse(pagedProducts);
    }
}