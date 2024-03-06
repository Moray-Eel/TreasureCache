using TreasureCache.Abstractions.Paging;
using TreasureCache.Infrastructure.Queries.Categories.Dtos;
using TreasureCache.Infrastructure.Queries.Products.Dtos;

namespace TreasureCache.Infrastructure.Queries.Products.GetProductsPanel;

public record ProductsPanelResponse(
    PagedList<ProductWithCategoryDto> Products,
    List<CategoryDto> Categories);