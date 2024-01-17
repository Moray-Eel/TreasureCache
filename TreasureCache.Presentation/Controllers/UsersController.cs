using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureCache.Abstractions.Mediator.Interfaces;
using TreasureCache.Infrastructure.Queries.User.GetUserModal;
using TreasureCache.Presentation.Mappers;
using TreasureCache.Presentation.Requests;
using TreasureCache.Presentation.ViewModels.Administration;

namespace TreasureCache.Presentation.Controllers;

public class UsersController : Controller
{
    private readonly IMediator _mediator;
    private readonly IValidator<UpdateUserRequest> _updateRequestValidator;
    public UsersController(IMediator mediator, IValidator<UpdateUserRequest> updateRequestValidator)
    {
        _mediator = mediator;
        _updateRequestValidator = updateRequestValidator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(UpdateUserRequest request)
    {
        var command = request.AsCommand();
        await _mediator.SendAsync(command);

        TempData["Success"] = "User updated successfully!";

        return RedirectToAction("UsersPanel", "Administration");
    }
}