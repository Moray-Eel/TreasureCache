using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using TreasureCache.Abstractions.Options;
using TreasureCache.Infrastructure.Authentication.Models;
using Product = TreasureCache.Core.Entities.Product;
using Task = DocumentFormat.OpenXml.Office2021.DocumentTasks.Task;

namespace TreasureCache.Application.Payment.Services;

public class StripePaymentService
{
    private readonly StripeOptions _options;

    public StripePaymentService(IOptions<StripeOptions> options)
    {
        _options = options.Value;
    }

    public async Task<Session> ConfigureCheckOutSession(Product product, int quantity,
        ApplicationUser user)
    {
        var currency = "usd";
        var successUrl = "http://localhost:5168/payment/success?session_id={CHECKOUT_SESSION_ID}";
        var cancelUrl = $"http://localhost:5168/payment/cancel";
        StripeConfiguration.ApiKey = _options.SecretKey;
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string>
            {
                "card"
            },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions()
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = currency,
                        UnitAmount =
                            (long) (Math.Round(
                                        product.BasePrice * (1 - (decimal) product.Discount / 100),
                                        2) *
                                    100), // Amount in smallest current
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = product.Name,
                            Description = product.Description,
                        },
                    },
                    Quantity = quantity
                },
            },
            Mode = "payment",
            SuccessUrl = successUrl,
            CancelUrl = cancelUrl,
            Metadata = new Dictionary<string, string>
            {
                {"ProductId", product.Id.ToString()},
                {"Quantity", quantity.ToString()},
                {"UserId", user.User.Id.ToString()}

            },
        };
        var service = new SessionService();
        return await service.CreateAsync(options);
    }

    public async Task<StripeSessionInfo> GetSessionInfo(string session_id)
    {
        var sessionService = new SessionService();
        var session = await sessionService.GetAsync(session_id);
        var metadata = session.Metadata;
        
        var userId = Guid.Parse(metadata["UserId"]);
        var quantity = int.Parse(metadata["Quantity"]);
        var productId = int.Parse(metadata["ProductId"]);
        var price = (decimal) session.AmountTotal! / 100;

        return new StripeSessionInfo(userId, productId, quantity, price);
    }
}