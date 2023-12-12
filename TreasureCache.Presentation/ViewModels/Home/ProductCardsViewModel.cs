using TreasureCache.Abstractions.Paging;
using TreasureCache.Infrastructure.Queries.Product.Dtos;

namespace TreasureCache.Presentation.ViewModels.Home;

public class ProductCardsViewModel
{
    public PagedList<ProductWithCategoryDto> Products { get; set; } = null!;
}