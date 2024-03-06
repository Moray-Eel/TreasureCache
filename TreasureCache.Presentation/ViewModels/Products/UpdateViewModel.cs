using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureCache.Presentation.Requests;

namespace TreasureCache.Presentation.ViewModels.Products;

public class UpdateViewModel
{
    public UpdateProductRequest Request { get; set; } = null!;
    public List<SelectListItem> Categories { get; set; } = null!;
}