using TreasureCache.Infrastructure.Queries.Category.Dtos;
using TreasureCache.Infrastructure.Queries.Product.Dtos;

namespace TreasureCache.Infrastructure.Queries.Product.GetProductUpdateData;

public record ProductUpdateResponse(ProductDto Product, List<CategoryDto> Categories);