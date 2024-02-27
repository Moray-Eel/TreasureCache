using Microsoft.AspNetCore.Mvc.Testing;
using TreasureCache.Presentation;
using Xunit;

namespace TreasureCache.Tests.Integration;

public class CreateProductEndpointTests : IClassFixture<TreasureCacheAppFactory>
{
    private readonly TreasureCacheAppFactory _factory;
    
    public CreateProductEndpointTests(TreasureCacheAppFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GivenValidProduct_CreatesProduct()
    {
        
    }
}