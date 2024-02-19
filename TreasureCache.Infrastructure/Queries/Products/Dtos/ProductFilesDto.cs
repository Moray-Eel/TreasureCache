namespace TreasureCache.Infrastructure.Queries.Products.Dtos;

public record ProductFilesDto(
    int Id,
    string LargeImagePath,
    string SmallImagePath,
    string? UserManualPath);