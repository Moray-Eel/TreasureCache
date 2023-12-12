using System.Diagnostics;
using Htmx;
using Microsoft.AspNetCore.Mvc;
using TreasureCache.Abstractions.Mediator.Interfaces;
using TreasureCache.Infrastructure.Queries.Product.GetProductCards;
using TreasureCache.Presentation.ViewModels.Error;
using TreasureCache.Presentation.ViewModels.Home;

namespace TreasureCache.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator;

    public HomeController(ILogger<HomeController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        var productResponse = await _mediator
            .SendAsync(new GetProductCardsQuery(page, pageSize));
        
        var model = new ProductCardsViewModel { Products = productResponse.Products };
        
        return Request.IsHtmx() 
            ? PartialView("Partial/_ProductCards", model) 
            : View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
            {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}