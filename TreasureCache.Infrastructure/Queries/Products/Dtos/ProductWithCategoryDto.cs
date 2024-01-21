using TreasureCache.Infrastructure.Queries.Categories.Dtos;

namespace TreasureCache.Infrastructure.Queries.Products.Dtos;

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