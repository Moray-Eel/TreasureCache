using Riok.Mapperly.Abstractions;

namespace TreasureCache.Infrastructure.Queries.Product.Dtos;

public record ProductFilesDto(
    int Id, 
    string LargeImagePath, 
    string SmallImagePath,
    string? UserManualPath);
