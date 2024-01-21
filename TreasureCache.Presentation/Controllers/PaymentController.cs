using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TreasureCache.Abstractions.Mediator.Interfaces;
using TreasureCache.Abstractions.Options;
using TreasureCache.Application.Payment;
using TreasureCache.Application.Payment.Commands.CheckOut;
using TreasureCache.Application.Payment.Commands.CreateOrder;

namespace TreasureCache.Presentation.Controllers;

[Authorize]
public class PaymentController : Controller
{
    private readonly IMediator _mediator;


    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> CheckOut(int productId, int quantity)
    {
        var response = await _mediator
            .SendAsync(new CheckOutCommand(productId, quantity));
        
        return Redirect(response.redirectUrl);
    }
    
    public async Task<IActionResult> Success(string session_id)
    {
        await _mediator.SendAsync(new CreateOrderCommand(session_id));
        
        TempData["Success"] = "Order placed successfully!";
        
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Cancel()
    {
        TempData["Error"] = "Your order has been canceled!";
        return RedirectToAction("Index", "Home");
    }
}