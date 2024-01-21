using TreasureCache.Abstractions.Mediator.Interfaces.Queries;

namespace TreasureCache.Infrastructure.Queries.PriceLists.GetPriceList;

public record GetPriceListQuery(string documentType) : IQuery<Stream>;