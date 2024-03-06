using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureCache.Abstractions.Mediator.Interfaces;
using TreasureCache.Application.Products.Commands.DeleteProductCommand;
using TreasureCache.Infrastructure.Queries.Categories.GetCategories;
using TreasureCache.Infrastructure.Queries.Products.GetProductById;
using TreasureCache.Infrastructure.Queries.Products.GetProductUpdateData;
using TreasureCache.Presentation.Mappers;
using TreasureCache.Presentation.Requests;
using TreasureCache.Presentation.ViewModels.Products;

namespace TreasureCache.Presentation.Controllers;

[Authorize(Roles = "Admin")]
public class ProductsController : Controller
{
    private readonly IMediator _mediator;
    private readonly IValidator<CreateProductRequest> _createRequestValidator;
    private readonly IValidator<UpdateProductRequest> _updateRequestValidator;

    public ProductsController(IMediator mediator,
        IValidator<CreateProductRequest> createRequestValidator,
        IValidator<UpdateProductRequest> updateRequestValidator)
    {
        _mediator = mediator;
        _createRequestValidator = createRequestValidator;
        _updateRequestValidator = updateRequestValidator;
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
    public async Task<IActionResult> Create(CreateProductRequest request)
    {
        var validationResult = await _createRequestValidator
            .ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(ModelState, nameof(request));
            return UnprocessableEntity(ModelState);
        }

        var command = await request.AsCommand();
        await _mediator.SendAsync(command);

        TempData["Success"] = "Product created successfully!";

        return Ok(new { url = Url.Action(nameof(AdministrationController.ProductsPanel), "Administration") });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProductCommand(id);
        await _mediator.SendAsync(command);

        TempData["Success"] = "Product deleted successfully!";

        return RedirectToAction("ProductsPanel", "Administration");
    }


    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var response = await _mediator
            .SendAsync(new GetProductUpdateDataQuery(id));

        var model = new UpdateViewModel()
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
            }).ToList(),
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateViewModel viewModel)
    {
        var validationResult = await _updateRequestValidator
            .ValidateAsync(viewModel.Request);

        if (!validationResult.IsValid)
        {
            var response = await _mediator.SendAsync(new GetCategoriesQuery());
            var model = new UpdateViewModel()
            {
                Request = viewModel.Request,
                Categories = response.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList(),
            };
            validationResult.AddToModelState(ModelState, nameof(viewModel.Request));
            return View("Update", model);
        }

        var command = await viewModel.Request
            .AsCommand();
        await _mediator.SendAsync(command);

        TempData["Success"] = "Product updated successfully!";


        return RedirectToAction("ProductsPanel", "Administration");
    }

    [AllowAnonymous]
    public async Task<IActionResult> View(int id)
    {
        var response = await _mediator
            .SendAsync(new GetProductByIdQuery(id));

        var model = new ViewViewModel
        {
            ProductDto = response,
            DiscountPrice =
                Math.Round(response.BasePrice * ((1 - ((decimal) response.Discount / 100))), 2)
        };

        return View(model);
    }
}