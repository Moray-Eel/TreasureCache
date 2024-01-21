using TreasureCache.Infrastructure.Queries.Products.Dtos;

namespace TreasureCache.Infrastructure.PriceLists.Generators;

public interface IPriceListGenerator
{
    protected IList<ProductWithCategoryDto> Products { get; set; }
    public Stream Generate(IList<ProductWithCategoryDto> products);
}