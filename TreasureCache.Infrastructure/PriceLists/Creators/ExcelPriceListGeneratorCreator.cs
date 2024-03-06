using TreasureCache.Infrastructure.PriceLists.Generators;

namespace TreasureCache.Infrastructure.PriceLists.Creators;

public class ExcelPriceListGeneratorCreator : PriceListGeneratorCreator
{
    public override IPriceListGenerator Create()
        => new ExcelPriceListGenerator();
}