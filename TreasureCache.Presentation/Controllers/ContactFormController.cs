using Microsoft.AspNetCore.Mvc;
using TreasureCache.Abstractions.Mediator.Interfaces;

namespace TreasureCache.Presentation.Controllers
{
    public class ContactFormController : Controller
    {
        private readonly IMediator _mediator;
        public ContactFormController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}