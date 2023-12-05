using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreasureCache.Application.Files.Services;
using TreasureCache.Application.Files.Services.Interfaces;
using TreasureCache.Application.Images.Services;
using TreasureCache.Application.Images.Services.Interfaces;
using TreasureCache.Core.Interfaces.Repositories;

namespace TreasureCache.Application;

public static class ApplicationInstaller
{
    public static IServiceCollection InstallApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IFileHandlerService, FileHandlerService>();
        services.AddTransient<IFileStorageService, FileStorageService>();
        services.AddTransient<IImageProcessor, ImageProcessor>();
        
        return services;
    }
}