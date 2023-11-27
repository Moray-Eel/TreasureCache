using Microsoft.AspNetCore.Http;
using TreasureCache.Core.Interfaces.Repositories;

namespace TreasureCache.Application.File;

public class FileHandlerService : IFileHandlerService
{
    private readonly IImageProcessor _imageProcessor;
    private readonly IFileStorageService _fileStorageService;
    public FileHandlerService(IImageProcessor imageProcessor, IFileStorageService fileStorageService)
    {
        _imageProcessor = imageProcessor;
        _fileStorageService = fileStorageService;
    }
    public static bool IsValidImage(byte[] bytes)
    {
        return bytes.Length < 10 ? false : bytes[0] == 137 && bytes[1] == 80 && bytes[2] == 78 && bytes[3] == 71 && bytes[4] == 13 && bytes[5] == 10 && bytes[6] == 26 && bytes[7] == 10; 
    }

    public Task Handle(byte[] file)
    {
        throw new NotImplementedException();
    }
}