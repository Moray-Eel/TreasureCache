using Riok.Mapperly.Abstractions;
using TreasureCache.Infrastructure.Queries.Category.Dtos;

namespace TreasureCache.Infrastructure.Queries.Category.Mappers;

[Mapper]
public static partial class CategoryMapper
{  
    public static partial IQueryable<CategoryDto> ProjectToDto(this IQueryable<Core.Entities.Category> categories);
}