using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureCache.Core.Entities;
using TreasureCache.Infrastructure.Queries.Category.Dtos;
using TreasureCache.Presentation.Requests;

namespace TreasureCache.Presentation.ViewModels.Product;

public class CreateViewModel
{
    public List<SelectListItem> Categories { get; set; } = null!;
    public CreateProductRequest Request { get; set; } = null!;
}