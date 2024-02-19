using Riok.Mapperly.Abstractions;
using TreasureCache.Infrastructure.Queries.Categories.Dtos;

namespace TreasureCache.Infrastructure.Queries.Categories.Mappers;

[Mapper]
public static partial class CategoryMapper
{
    public static partial IQueryable<CategoryDto> ProjectToDto(
        this IQueryable<Core.Entities.Category> categories);
}