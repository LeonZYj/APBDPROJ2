using APBDPROLEON.DeviceManagerInterface;

namespace APBDPROLEON.DeviceManagerSplitted;

public class FileService : IFileService
{
    public List<string> ReadFile(string filePath)
    {
        if (!File.Exists(filePath))
            throw new Exception("wrong file path");
        
        return File.ReadAllLines(filePath).ToList();                        
    }

    public void writeLineToFile(string filePath, string line)
    {
        File.WriteAllText(filePath, line);
    }
}