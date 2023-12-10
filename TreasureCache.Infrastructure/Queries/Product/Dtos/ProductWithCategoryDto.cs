using TreasureCache.Infrastructure.Queries.Category.Dtos;

namespace TreasureCache.Infrastructure.Queries.Product.Dtos;

public record ProductWithCategoryDto(
    int Id, 
    string Name, 
    string Description,
    decimal BasePrice, 
    int Discount, 
    int Count, 
    DateTimeOffset CreatedAt,
    bool IsActive, 
    ProductFilesDto ProductFiles,
    CategoryDto Category);