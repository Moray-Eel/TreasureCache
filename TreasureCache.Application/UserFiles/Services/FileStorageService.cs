using Microsoft.AspNetCore.Hosting;
using TreasureCache.Application.UserFiles.Constants;
using TreasureCache.Application.UserFiles.Dtos;
using TreasureCache.Application.UserFiles.Services.Interfaces;

namespace TreasureCache.Application.UserFiles.Services;

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

        var relativePath = Path.Combine(directory, GenerateSecurePath(file.Extension));
        var path = Path.Combine(rootDirectory, relativePath);
        await File.WriteAllBytesAsync(path, file.ByteContent);

        return relativePath;
    }

    private static string GenerateSecurePath(string extension)
    {
        var secureSignature = Guid.NewGuid().ToString();
        return String.Concat(secureSignature, extension);
    }
}