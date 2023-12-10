using TreasureCache.Abstractions.Paging;
using TreasureCache.Infrastructure.Queries.Product.Dtos;

namespace TreasureCache.Presentation.ViewModels.Administration;

public class ProductsPanelViewModel
{
    public PagedList<ProductWithCategoryDto> Products { get; set; } = null!;
}