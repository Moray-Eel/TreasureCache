using TreasureCache.Abstractions.Mediator.Interfaces.Queries;
using TreasureCache.Abstractions.Paging;

namespace TreasureCache.Infrastructure.Queries.Products.GetProductsPanel;

public record GetProductsPanelQuery(int Page, int PageSize) : 
    PagedRequest(Page, PageSize), 
    IQuery<ProductsPanelResponse>;