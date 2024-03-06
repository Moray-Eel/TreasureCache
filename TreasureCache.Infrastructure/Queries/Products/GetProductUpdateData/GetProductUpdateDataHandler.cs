using Microsoft.EntityFrameworkCore;
using TreasureCache.Abstractions.Mediator.Interfaces.Queries.Handlers;
using TreasureCache.Core.Interfaces.Repositories;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Infrastructure.Queries.Categories.Mappers;
using TreasureCache.Infrastructure.Queries.Products.Mappers;

namespace TreasureCache.Infrastructure.Queries.Products.GetProductUpdateData;

public class
    GetProductUpdateDataHandler : IQueryHandler<GetProductUpdateDataQuery, ProductUpdateResponse>
{
    private readonly ApplicationContext _context;
    private readonly IProductRepository _repository;

    public GetProductUpdateDataHandler(ApplicationContext context, IProductRepository repository)
    {
        _context = context;
        _repository = repository;
    }

    public async Task<ProductUpdateResponse> HandleAsync(GetProductUpdateDataQuery query,
        CancellationToken cancellationToken = default)
    {
        var product = await _repository
            .GetById(query.Id, cancellationToken);
        var productDto = product?.ProjectToDto() ?? throw new NullReferenceException();

        var categories = await _context.Categories
            .ProjectToDto()
            .ToListAsync(cancellationToken);

        return new ProductUpdateResponse(productDto, categories);
    }
}