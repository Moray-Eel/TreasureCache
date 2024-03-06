using TreasureCache.Infrastructure.PriceLists.Generators;

namespace TreasureCache.Infrastructure.PriceLists.Creators;

public abstract class PriceListGeneratorCreator
{
    public abstract IPriceListGenerator Create();
}