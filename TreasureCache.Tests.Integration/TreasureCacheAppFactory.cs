using System.ComponentModel;
using Xunit;

namespace TreasureCache.Tests.Integration;

public class TreasureCacheAppFactory : TestWebAppFactory, IAsyncLifetime
{
    public Task InitializeAsync()
    {
        return _psotgreSqlContainer.StartAsync();
    }

    public new Task DisposeAsync()
    {
        return _psotgreSqlContainer.StopAsync();
    }
}