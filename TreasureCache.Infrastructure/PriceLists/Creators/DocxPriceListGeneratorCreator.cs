using TreasureCache.Infrastructure.PriceLists.Generators;

namespace TreasureCache.Infrastructure.PriceLists.Creators;

public class DocxPriceListGeneratorCreator : PriceListGeneratorCreator
{
    public override IPriceListGenerator Create() 
        => new DocXPriceListGenerator();
}