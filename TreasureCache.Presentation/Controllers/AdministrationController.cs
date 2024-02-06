using Htmx;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureCache.Abstractions.Mediator.Interfaces;
using TreasureCache.Infrastructure.Queries.PriceLists.GetPriceList;
using TreasureCache.Infrastructure.Queries.Products.GetProductById;
using TreasureCache.Infrastructure.Queries.Products.GetProductsPanel;
using TreasureCache.Infrastructure.Queries.Users.GetUserModal;
using TreasureCache.Infrastructure.Queries.Users.GetUsersPanel;
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
            Products = response.Products,
            Categories = response.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList(),
        };
        
        return Request.IsHtmx() 
            ? PartialView("Partial/_ProductsTable",model) 
            : View(model);
    }
    
    public async Task<IActionResult> ProductModal(int id)
    {
        var response = await _mediator.SendAsync(new GetProductByIdQuery(id));

        var model = new ProductModalViewModel()
        {
            Id = response.Id,
            Name = response.Name,
            Description = response.Description,
            BasePrice = response.BasePrice,
            Discount = response.Discount,
            Count = response.Count,
            IsActive = response.IsActive,
        };
        return PartialView("Partial/_ProductModal", model);
    }
    
    [HttpGet]
    public async Task<FileStreamResult> GeneratePriceList(string documentType, int categoryId)
    {
        var response = await _mediator
            .SendAsync(new GetPriceListQuery(documentType, categoryId));
        
        return File(response, DocumentMimeType(documentType), DocumentName(documentType));
    }
    
    private string DocumentMimeType(string documentType)
    {
        return documentType switch
        {
            "Docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            "Excel" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            _ => "application/pdf",
        };
    }
    private string DocumentName(string documentType)
    {
        return documentType switch
        {
            "Docx" => "priceList.docx",
            "Excel" => "priceList.xlsx",
            _ => "priceList.pdf",
        };
    }
}