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
                Console.WriteLine($"Error: File '{filePath}' not found.");
                return;
            }

            try
            {
                DeviceManager manager = new DeviceManager(filePath);

                // ✅ Show all devices
                Console.WriteLine("\n📌 Displaying All Devices:");
                manager.ShowAllDevices();

                // ✅ Turn on devices
                Console.WriteLine("\n🚀 Attempting to Turn On Devices:");
                foreach (var device in manager.GetDevices()) // GetDevices() should return the list
                {
                    try
                    {
                        device.TurnOn();
                        Console.WriteLine($"✅ {device.Name} is now ON.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"⚠️ Cannot turn on {device.Name}: {ex.Message}");
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