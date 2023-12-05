using TreasureCache.Application.Files.Dtos;

namespace TreasureCache.Application.Files.Services.Interfaces;

public interface IFileStorageService
{
    public Task<string> GetPathAndWrite(FileDto file);
}