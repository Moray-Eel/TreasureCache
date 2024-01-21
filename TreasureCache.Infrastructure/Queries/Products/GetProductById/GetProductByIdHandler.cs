using Microsoft.EntityFrameworkCore;
using TreasureCache.Abstractions.Mediator.Interfaces.Queries.Handlers;
using TreasureCache.Core.Interfaces.Repositories;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Infrastructure.Queries.Products.Dtos;
using TreasureCache.Infrastructure.Queries.Products.Mappers;

namespace TreasureCache.Infrastructure.Queries.Products.GetProductById;

public class GetProductByIdHandler : IQueryHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IProductRepository _repository;

    public GetProductByIdHandler(ApplicationContext context, IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductDto> HandleAsync(GetProductByIdQuery query, CancellationToken cancellationToken = default)
    {
        var product = await _repository.GetById(query.ProductId, cancellationToken) 
                      ?? throw new NullReferenceException("Product not found");
        
        return product
            .ProjectToDto();
    }
}