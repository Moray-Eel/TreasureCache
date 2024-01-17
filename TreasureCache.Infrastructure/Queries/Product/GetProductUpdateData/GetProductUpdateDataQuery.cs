using TreasureCache.Abstractions.Mediator.Interfaces.Queries;

namespace TreasureCache.Infrastructure.Queries.Product.GetProductUpdateData;

public record GetProductUpdateDataQuery(int Id) : IQuery<ProductUpdateResponse>;

