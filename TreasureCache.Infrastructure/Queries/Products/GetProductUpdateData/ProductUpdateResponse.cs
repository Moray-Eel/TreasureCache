using TreasureCache.Infrastructure.Queries.Categories.Dtos;
using TreasureCache.Infrastructure.Queries.Products.Dtos;

namespace TreasureCache.Infrastructure.Queries.Products.GetProductUpdateData;

public record ProductUpdateResponse(ProductDto Product, List<CategoryDto> Categories);