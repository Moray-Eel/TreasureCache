using TreasureCache.Abstractions.Mediator.Interfaces.Queries;
using TreasureCache.Infrastructure.Queries.Products.Dtos;

namespace TreasureCache.Infrastructure.Queries.Products.GetProductById;

public record GetProductByIdQuery(int ProductId) : IQuery<ProductDto>;