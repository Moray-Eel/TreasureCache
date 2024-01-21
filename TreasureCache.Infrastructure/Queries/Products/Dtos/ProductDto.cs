namespace TreasureCache.Infrastructure.Queries.Products.Dtos;

public record ProductDto(
    int Id, 
    string Name, 
    string Description,
    decimal BasePrice, 
    int Discount, 
    int Count, 
    DateTimeOffset CreatedAt,
    bool IsActive,
    int CategoryId,
    ProductFilesDto ProductFiles
    );