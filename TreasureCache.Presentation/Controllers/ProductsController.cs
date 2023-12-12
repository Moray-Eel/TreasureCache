using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureCache.Abstractions.Mediator.Interfaces;
using TreasureCache.Application.Products.Commands.DeleteProductCommand;
using TreasureCache.Application.Products.Commands.UpdateProductCommand;
using TreasureCache.Infrastructure.Queries.Category;
using TreasureCache.Infrastructure.Queries.Category.GetCategories;
using TreasureCache.Presentation.Mappers;
using TreasureCache.Presentation.Requests;
using TreasureCache.Presentation.ViewModels.Products;

namespace TreasureCache.Presentation.Controllers;

[Authorize(Roles = "Admin")]
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
        var command = await model.Request.AsCommand();
        await _mediator.SendAsync(command);
        
        TempData["Success"] = "Product created successfully!";
        
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProductCommand(id);
        await _mediator.SendAsync(command);
        
        TempData["Success"] = "Product deleted successfully!";

        return RedirectToAction("ProductsPanel", "Administration");
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductRequest request)
    {
        var command = request.AsCommand();
        await _mediator.SendAsync(command);

        TempData["Success"] = "Product updated successfully!";

        return RedirectToAction("ProductsPanel", "Administration");
    }
}