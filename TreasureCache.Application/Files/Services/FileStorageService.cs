using System.Security.Cryptography;
using Microsoft.AspNetCore.Hosting;
using TreasureCache.Application.Files.Constants;
using TreasureCache.Application.Files.Dtos;
using TreasureCache.Application.Files.Services.Interfaces;

namespace TreasureCache.Application.Files.Services;

public class FileStorageService : IFileStorageService
{
    private readonly IWebHostEnvironment _env;

    public FileStorageService(IWebHostEnvironment webHostEnvironment)
    {
        _env = webHostEnvironment;
    }
    public async Task<string> GetPathAndWrite(FileDto file)
    {
        var rootDirectory = _env.WebRootPath;
        var directory = file.FileType == FileType.Image ? FilePaths.Image : FilePaths.Document;
        
        var path = Path.Combine(rootDirectory, directory, GenerateSecurePath(file.Extension));
        await File.WriteAllBytesAsync(path, file.ByteContent);
        
        return path;
    }
    
    private static string GenerateSecurePath(string extension)
    {
        var secureSignature = Guid.NewGuid().ToString();
        return String.Concat(secureSignature, extension);
    }
}