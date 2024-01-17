using TreasureCache.Abstractions.Mediator.Interfaces.Queries;

namespace TreasureCache.Infrastructure.Queries.Product.GetProduct;

public record GetProductQuery(int Id) : IQuery<ProductResponse>;

