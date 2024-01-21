using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TreasureCache.Abstractions.Mediator.Interfaces.Commands.Handlers;
using TreasureCache.Application.Payment.Services;
using TreasureCache.Infrastructure.Authentication.Models;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Infrastructure.Persistence.Repositories;

namespace TreasureCache.Application.Payment.Commands.CheckOut;

public class CheckOutCommandHandler : ICommandHandler<CheckOutCommand, CheckoutResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationContext _context;
    private readonly ProductRepository _productRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly StripePaymentService _stripePaymentService;
    private readonly IUserRepository _userRepository;

    public CheckOutCommandHandler(IHttpContextAccessor httpContextAccessor, ProductRepository productRepository, 
        ApplicationContext context, UserManager<ApplicationUser> userManager, StripePaymentService stripePaymentService, IUserRepository userRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _productRepository = productRepository;
        _context = context;
        _userManager = userManager;
        _stripePaymentService = stripePaymentService;
        _userRepository = userRepository;
    }

    public async Task<CheckoutResponse> HandleAsync(CheckOutCommand command, CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.GetById(command.ProductId, cancellationToken)
                      ?? throw new NullReferenceException("Product not found!");
        
        var userId = _userManager
                         .GetUserId(_httpContextAccessor.HttpContext.User) 
                     ?? throw new NullReferenceException("User not found");

        var user = await _userRepository
            .GetById(userId, cancellationToken);
        
        var session = await _stripePaymentService.
            ConfigureCheckOutSession(product, command.Quantity, user);

        return new CheckoutResponse(session.Url);
    }
}