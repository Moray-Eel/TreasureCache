using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreasureCache.Abstractions.Mediator.Interfaces;
using TreasureCache.Core.Entities;
using TreasureCache.Infrastructure.Authentication.Models;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Presentation.ViewModels.ContactForm;

namespace TreasureCache.Presentation.Controllers
{
    public class ContactFormController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ContactFormController(IMediator mediator, ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Send(ContactFormViewModel viewModel)
        {
            var userId = _userManager.GetUserId(HttpContext.User)
                         ?? throw new NullReferenceException("User not found");

            var user = await _context.Users
                .Include(u => u.User)
                .FirstAsync(u => u.Id == userId);
            
            var form = new ContactForm
            {
                Message = viewModel.Message,
                ContactReason = viewModel.ContactReason,
                Sender = user.User,
            };
            
            await _context.ContactForms.AddAsync(form);
            await _context.SaveChangesAsync();
            
            TempData["Success"] = "Message sent successfully!";

            return RedirectToAction("Index", "Home");
        }
    }
}