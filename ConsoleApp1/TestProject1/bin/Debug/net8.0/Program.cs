using System;
using System.IO;

namespace APBDPROLEON
{
    class Program
    {
        static void Main()
        {
            string filePath = "input.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"{filePath}' not found.");
                return;
            }

            try
            {
                DeviceManager manager = new DeviceManager(filePath);
                
                Console.WriteLine("\nDisplaying All Devices:");
                manager.ShowAllDevices();
                
                Console.WriteLine("\nAttempting to Turn On Devices:");
                foreach (var device in manager.GetDevices())
                {
                    try
                    {
                        device.TurnOn();
                        Console.WriteLine($"{device.Name} is now ON.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Cannot turn on {device.Name}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}