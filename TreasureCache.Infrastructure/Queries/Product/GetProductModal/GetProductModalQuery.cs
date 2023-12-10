using TreasureCache.Abstractions.Mediator.Interfaces.Queries;

namespace TreasureCache.Infrastructure.Queries.Product.GetProductModal;

public record GetProductModalQuery(int Id) : IQuery<ProductModalResponse>;

