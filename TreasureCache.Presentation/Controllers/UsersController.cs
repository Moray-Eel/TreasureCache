using Microsoft.AspNetCore.Mvc;
using TreasureCache.Abstractions.Mediator.Interfaces;
using TreasureCache.Presentation.Mappers;
using TreasureCache.Presentation.Requests;
using TreasureCache.Presentation.ViewModels.Administration;

namespace TreasureCache.Presentation.Controllers;

public class UsersController : Controller
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(UsersModalViewModel viewModel)
    {
        var command = viewModel.Request.AsCommand();
        await _mediator.SendAsync(command);

        TempData["Success"] = "User updated successfully!";

        return RedirectToAction("UsersPanel", "Administration");
    }
}