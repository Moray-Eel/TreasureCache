using Microsoft.AspNetCore.Mvc;
using TreasureCache.Abstractions.Mediator.Interfaces;

namespace TreasureCache.Presentation.Controllers;

public class TestController : ControllerBase
{
    private readonly IMediator _mediator;
    public TestController(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IActionResult> Test()
    {
        return Ok();
    }
}