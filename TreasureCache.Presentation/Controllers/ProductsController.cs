using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureCache.Abstractions.Mediator.Interfaces;
using TreasureCache.Infrastructure.Queries.Category;
using TreasureCache.Presentation.Mappers;
using TreasureCache.Presentation.ViewModels.Product;

namespace TreasureCache.Presentation.Controllers;

public class ProductsController : Controller
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var model = new CreateViewModel();
        var categories = await _mediator
            .SendAsync(new GetCategoriesQuery());

        var selectOptions = categories
            .Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
        
        model.Categories = selectOptions;
        
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateViewModel model)
    {
        return View(model);
    }
}