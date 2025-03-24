namespace APBDPROLEON.DeviceManagerInterface;

public interface FactoryDeviceManagerInterface
{
    IDeviceManagerMainOperations Create(string filepath);
}