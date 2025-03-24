namespace APBDPROLEON.DeviceManagerInterface;

public interface IFileService
{
    List <string> ReadFile(string filePath);
    void writeLineToFile(string filePath, string line);
}