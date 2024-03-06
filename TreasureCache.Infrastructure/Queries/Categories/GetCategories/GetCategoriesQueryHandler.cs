using Microsoft.EntityFrameworkCore;
using TreasureCache.Abstractions.Mediator.Interfaces.Queries.Handlers;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Infrastructure.Queries.Categories.Dtos;
using TreasureCache.Infrastructure.Queries.Categories.Mappers;

namespace TreasureCache.Infrastructure.Queries.Categories.GetCategories;

public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, List<CategoryDto>>
{
    private readonly ApplicationContext _context;

    public GetCategoriesQueryHandler(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> HandleAsync(GetCategoriesQuery command,
        CancellationToken cancellationToken)
    {
        return await _context.Categories
            .ProjectToDto()
            .ToListAsync(cancellationToken);
    }
}