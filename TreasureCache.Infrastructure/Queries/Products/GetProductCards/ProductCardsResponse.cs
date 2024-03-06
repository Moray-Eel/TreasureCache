using TreasureCache.Abstractions.Paging;
using TreasureCache.Infrastructure.Queries.Products.Dtos;

namespace TreasureCache.Infrastructure.Queries.Products.GetProductCards;

public record ProductCardsResponse(PagedList<ProductWithCategoryDto> Products);