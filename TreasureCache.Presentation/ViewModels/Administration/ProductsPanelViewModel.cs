using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureCache.Abstractions.Paging;
using TreasureCache.Infrastructure.Queries.Products.Dtos;

namespace TreasureCache.Presentation.ViewModels.Administration;

public class ProductsPanelViewModel
{
    public PagedList<ProductWithCategoryDto> Products { get; set; } = null!;
    public string DocumentType { get; set; } = null!;
    public List<SelectListItem> Categories { get; set; } = null!;
    public int CategoryId { get; set; }
}