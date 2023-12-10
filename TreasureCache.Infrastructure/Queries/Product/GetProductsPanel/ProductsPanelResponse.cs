using TreasureCache.Abstractions.Paging;
using TreasureCache.Infrastructure.Queries.Product.Dtos;

namespace TreasureCache.Infrastructure.Queries.Product.GetProductsPanel;

public record ProductsPanelResponse(PagedList<ProductWithCategoryDto> Products);
