namespace TreasureCache.Application.Products.Dtos;

public record ProductDto(string Name, string Description, decimal Price, int Discount, int Count, bool IsActive, int CategoryId);