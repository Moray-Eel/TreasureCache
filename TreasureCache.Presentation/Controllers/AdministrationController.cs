using Htmx;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureCache.Abstractions.Mediator.Interfaces;
using TreasureCache.Infrastructure.Authentication.Constants;
using TreasureCache.Infrastructure.Queries.Product;
using TreasureCache.Infrastructure.Queries.Product.Dtos;
using TreasureCache.Infrastructure.Queries.Product.GetProduct;
using TreasureCache.Infrastructure.Queries.Product.GetProductsPanel;
using TreasureCache.Infrastructure.Queries.Product.GetProductUpdateData;
using TreasureCache.Infrastructure.Queries.User.GetUserModal;
using TreasureCache.Infrastructure.Queries.User.GetUsersPanel;
using TreasureCache.Presentation.Requests;
using TreasureCache.Presentation.ViewModels.Administration;

namespace TreasureCache.Presentation.Controllers;

[Authorize(Roles = "Admin")]
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
    public async Task<IActionResult> UsersPanel(int page = 1, int pageSize = 10)
    {
    
        var response = await _mediator.SendAsync(new GetUsersPanelQuery(page, pageSize));
        var model = new UsersPanelViewModel()
        {
            Users = response.Users,
        };
        
        return Request.IsHtmx() 
            ? PartialView("Partial/_UsersTable",model) 
            : View(model); 
    }
    
    [HttpGet]
    public async Task<IActionResult> UserModal(string id)
    {
        var response = await _mediator.SendAsync(new GetUserModalQuery(id));
        
        var model = new UsersModalViewModel()
        {
            Request = new UpdateUserRequest(
                response.User.Id,
                response.UserRoles.Select(x => x.Id).ToList(),
                response.User.DomainUser.SignedForNewsletter,
                response.User.DomainUser.PersonalDiscount
                ),
            Roles = response.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            }).ToList(),
        };

        return PartialView("Partial/_UserModal", model);
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
        var response = await _mediator.SendAsync(new GetProductQuery(id));

        var model = new ProductModalViewModel()
        {
            Id = response.Product.Id,
            Name = response.Product.Name,
            Description = response.Product.Description,
            BasePrice = response.Product.BasePrice,
            Discount = response.Product.Discount,
            Count = response.Product.Count,
            IsActive = response.Product.IsActive,
        };

        return PartialView("Partial/_ProductModal", model);
    }
}