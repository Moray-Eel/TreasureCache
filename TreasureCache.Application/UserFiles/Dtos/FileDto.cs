namespace TreasureCache.Application.UserFiles.Dtos;

public class FileDto
{
    public string Name { get; set; }
    public string Extension { get; set; }
    public byte[] ByteContent { get; set; }
    public FileType FileType { get; set; }
}