using TreasureCache.Abstractions.Paging;
using TreasureCache.Infrastructure.Queries.Products.Dtos;

namespace TreasureCache.Presentation.ViewModels.Home;

public class ProductCardsViewModel
{
    public PagedList<ProductWithCategoryDto> Products { get; set; } = null!;
}