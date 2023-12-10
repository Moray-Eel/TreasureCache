using TreasureCache.Infrastructure.Queries.Category.Dtos;
using TreasureCache.Infrastructure.Queries.Product.Dtos;

namespace TreasureCache.Infrastructure.Queries.Product.GetProductModal;

public record ProductModalResponse(ProductDto Product, List<CategoryDto> Categories);