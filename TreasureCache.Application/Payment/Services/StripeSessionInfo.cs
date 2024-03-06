namespace TreasureCache.Application.Payment.Services;

public record StripeSessionInfo(Guid UserId, int ProductId, int Quantity, decimal TotalPrice);