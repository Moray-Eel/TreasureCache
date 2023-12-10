using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureCache.Abstractions.Mediator.Interfaces;
using TreasureCache.Infrastructure.Queries.Product;
using TreasureCache.Infrastructure.Queries.Product.Dtos;
using TreasureCache.Infrastructure.Queries.Product.GetProductModal;
using TreasureCache.Infrastructure.Queries.Product.GetProductsPanel;
using TreasureCache.Presentation.Requests;
using TreasureCache.Presentation.ViewModels.Administration;

namespace TreasureCache.Presentation.Controllers;

public class AdministrationController : Controller
{

    private readonly IMediator _mediator;
    public AdministrationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> ProductsPanel(int page = 1, int pageSize = 10)
    {
        var response = await _mediator.SendAsync(new GetProductsPanelQuery(page, pageSize));
        var model = new ProductsPanelViewModel()
        {
            Products = response.Products
        };
        
        return Request.IsHtmx() 
            ? PartialView("Partial/_ProductsTable",model) 
            : View(model);
    }
    
    public async Task<IActionResult> ProductModal(int id)
    {
        var response = await _mediator.SendAsync(new GetProductModalQuery(id));

        var model = new ProductModalViewModel()
        {
            Request = new UpdateProductRequest(
                response.Product.Id, 
                response.Product.Name,
                response.Product.Description,
                response.Product.BasePrice,
                response.Product.Discount,
                response.Product.Count,
                response.Product.IsActive,
                response.Product.CategoryId,
                null,
                null,
                null,
                response.Product.ProductFiles.LargeImagePath,
                response.Product.ProductFiles.SmallImagePath,
                response.Product.ProductFiles.UserManualPath
                    ),
            Categories = response.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList()
        };

        return PartialView("Partial/_ProductModal", model);
    }
}