namespace TreasureCache.Abstractions.Options;

public class StripeOptions
{
    public string PublishableKey { get; set; } = null!;
    public string SecretKey { get; set; } = null!;
}