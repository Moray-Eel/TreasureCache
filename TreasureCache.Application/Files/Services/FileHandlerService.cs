using TreasureCache.Application.Files.Dtos;
using TreasureCache.Application.Files.Services.Interfaces;
using TreasureCache.Application.Images.Services.Interfaces;

namespace TreasureCache.Application.Files.Services;

public class FileHandlerService : IFileHandlerService
{
    private readonly IImageProcessor _imageProcessor;
    private readonly IFileStorageService _fileStorageService;
    
    public FileHandlerService(IImageProcessor imageProcessor, IFileStorageService fileStorageService)
    {
        _imageProcessor = imageProcessor;
        _fileStorageService = fileStorageService;
    }
    
    public async Task<(string, string, string?)> Handle(FileDto smallImage, FileDto largeImage, FileDto? userManual)
    {
        smallImage = await _imageProcessor.Resize(smallImage, 300, 250);
        largeImage = await _imageProcessor.Resize(largeImage, 800, 400);
        
        var smallImagePath = await _fileStorageService.GetPathAndWrite(smallImage);
        var largeImagePath = await _fileStorageService.GetPathAndWrite(largeImage);
        var userManualPath = userManual is null 
            ? null : 
            await _fileStorageService.GetPathAndWrite(userManual);

        return (smallImagePath, largeImagePath, userManualPath);
    }
}