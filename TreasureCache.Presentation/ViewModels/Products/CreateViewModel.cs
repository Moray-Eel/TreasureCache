using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureCache.Presentation.Requests;

namespace TreasureCache.Presentation.ViewModels.Products;

public class CreateViewModel
{
    public List<SelectListItem> Categories { get; set; } = null!;
    public CreateProductRequest Request { get; set; } = null!;
}