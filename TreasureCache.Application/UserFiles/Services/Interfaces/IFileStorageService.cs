using TreasureCache.Application.UserFiles.Dtos;

namespace TreasureCache.Application.UserFiles.Services.Interfaces;

public interface IFileStorageService
{
    public Task<string> GetPathAndWrite(FileDto file);
}