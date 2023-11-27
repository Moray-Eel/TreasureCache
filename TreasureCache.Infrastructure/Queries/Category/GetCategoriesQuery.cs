using TreasureCache.Abstractions.Mediator.Interfaces.Queries;
using TreasureCache.Infrastructure.Queries.Category.Dtos;

namespace TreasureCache.Infrastructure.Queries.Category;

public record GetCategoriesQuery : IQuery<List<CategoryDto>>;