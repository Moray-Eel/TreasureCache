using TreasureCache.Abstractions.Mediator.Interfaces.Queries;
using TreasureCache.Infrastructure.Queries.Categories.Dtos;

namespace TreasureCache.Infrastructure.Queries.Categories.GetCategories;

public record GetCategoriesQuery : IQuery<List<CategoryDto>>;