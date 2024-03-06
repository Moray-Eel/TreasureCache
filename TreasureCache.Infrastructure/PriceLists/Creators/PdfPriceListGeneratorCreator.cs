using TreasureCache.Infrastructure.PriceLists.Generators;

namespace TreasureCache.Infrastructure.PriceLists.Creators;

public class PdfPriceListGeneratorCreator : PriceListGeneratorCreator
{
    public override IPriceListGenerator Create()
        => new PdfPriceListGenerator();
}