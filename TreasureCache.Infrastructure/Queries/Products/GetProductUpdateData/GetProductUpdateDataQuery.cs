using TreasureCache.Abstractions.Mediator.Interfaces.Queries;

namespace TreasureCache.Infrastructure.Queries.Products.GetProductUpdateData;

public record GetProductUpdateDataQuery(int Id) : IQuery<ProductUpdateResponse>;

