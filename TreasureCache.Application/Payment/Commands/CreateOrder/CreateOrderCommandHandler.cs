using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TreasureCache.Abstractions.Mediator.Interfaces.Commands;
using TreasureCache.Abstractions.Mediator.Interfaces.Commands.Handlers;
using TreasureCache.Application.Payment.Services;
using TreasureCache.Core.Entities;
using TreasureCache.Infrastructure.Authentication.Models;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Infrastructure.Persistence.Repositories;

namespace TreasureCache.Application.Payment.Commands.CreateOrder;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationContext _context;
    private readonly ProductRepository _productRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly StripePaymentService _stripePaymentService;

    public CreateOrderCommandHandler(IHttpContextAccessor httpContextAccessor,
        ProductRepository productRepository,
        ApplicationContext context, UserManager<ApplicationUser> userManager,
        StripePaymentService stripePaymentService)
    {
        _httpContextAccessor = httpContextAccessor;
        _productRepository = productRepository;
        _context = context;
        _userManager = userManager;
        _stripePaymentService = stripePaymentService;
    }

    public async Task HandleAsync(CreateOrderCommand command,
        CancellationToken cancellationToken = default)
    {
        var sesionInfo = await _stripePaymentService
            .GetSessionInfo(command.sessionId);

        var user = await _context.DomainUsers
            .Include(u => u.Address)
            .FirstAsync(u => u.Id == sesionInfo.UserId, cancellationToken);

        var order = new Order()
        {
            Buyer = user,
            TotalPrice = sesionInfo.TotalPrice,
            ShippingAddress = user.Address,
            OrderItems = new List<OrderItem>()
            {
                new OrderItem()
                {
                    Quantity = sesionInfo.Quantity,
                    ProductId = sesionInfo.ProductId,
                    AggregatePrice = sesionInfo.TotalPrice
                }
            },
        };
        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}