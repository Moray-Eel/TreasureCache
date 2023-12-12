using TreasureCache.Abstractions.Paging;
using TreasureCache.Infrastructure.Queries.Product.Dtos;

namespace TreasureCache.Infrastructure.Queries.Product.GetProductCards;

public record ProductCardsResponse(PagedList<ProductWithCategoryDto> Products);