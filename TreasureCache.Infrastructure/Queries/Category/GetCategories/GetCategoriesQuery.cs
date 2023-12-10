using TreasureCache.Abstractions.Mediator.Interfaces.Queries;
using TreasureCache.Infrastructure.Queries.Category.Dtos;

namespace TreasureCache.Infrastructure.Queries.Category.GetCategories;

public record GetCategoriesQuery : IQuery<List<CategoryDto>>;