using TreasureCache.Application.Files.Dtos;

namespace TreasureCache.Application.Files.Services.Interfaces;

public interface IFileHandlerService
{
    public Task<(string,string, string?)> Handle(FileDto smallImage, FileDto largeImage, FileDto? userManual);
}