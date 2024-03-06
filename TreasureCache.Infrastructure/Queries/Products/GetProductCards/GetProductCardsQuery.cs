using TreasureCache.Abstractions.Mediator.Interfaces.Queries;
using TreasureCache.Abstractions.Paging;

namespace TreasureCache.Infrastructure.Queries.Products.GetProductCards;

public record GetProductCardsQuery(int Page, int PageSize) :
    PagedRequest(Page, PageSize),
    IQuery<ProductCardsResponse>;