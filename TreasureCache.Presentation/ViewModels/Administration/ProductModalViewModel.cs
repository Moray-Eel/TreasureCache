using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureCache.Infrastructure.Queries.Category.Dtos;
using TreasureCache.Infrastructure.Queries.Product.Dtos;
using TreasureCache.Presentation.Requests;

namespace TreasureCache.Presentation.ViewModels.Administration;

public class ProductModalViewModel
{
    public UpdateProductRequest Request { get; set; } = null!;
    public List<SelectListItem> Categories { get; set; } = null!;
}