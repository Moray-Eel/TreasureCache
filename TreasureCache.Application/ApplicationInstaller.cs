using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuestPDF.Infrastructure;
using TreasureCache.Application.Images.Services;
using TreasureCache.Application.Images.Services.Interfaces;
using TreasureCache.Application.Payment.Services;
using TreasureCache.Application.UserFiles.Services;
using TreasureCache.Application.UserFiles.Services.Interfaces;
using TreasureCache.Core.Interfaces.Repositories;
using TreasureCache.Infrastructure.PriceLists;

namespace TreasureCache.Application;

public static class ApplicationInstaller
{
    public static IServiceCollection InstallApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IFileHandlerService, FileHandlerService>();
        services.AddTransient<IFileStorageService, FileStorageService>();
        services.AddTransient<IImageProcessor, ImageProcessor>();
        services.AddTransient<StripePaymentService>();
        
        return services;
    }
}