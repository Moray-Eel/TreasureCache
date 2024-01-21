using TreasureCache.Application.UserFiles.Dtos;

namespace TreasureCache.Application.UserFiles.Services.Interfaces;

public interface IFileHandlerService
{
    public Task<(string,string, string?)> Handle(FileDto smallImage, FileDto largeImage, FileDto? userManual);
}