using TreasureCache.Infrastructure.Queries.Products.Dtos;

namespace TreasureCache.Presentation.ViewModels.Products;

public class ViewViewModel
{
    public ProductDto ProductDto { get; set; } = null!;
    public decimal DiscountPrice { get; set; }
    public int Quantity { get; set; } = 1;
}