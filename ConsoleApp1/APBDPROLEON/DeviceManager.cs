

namespace APBDPROLEON
{
    public class DeviceManager
    {
        private List<Device> devices;
        private string filePath;
        private const int maxCapacity = 15;

        public DeviceManager(string filePath)
        {
            this.filePath = filePath;
            devices = new List<Device>();

            LoadDevicesFromFile();
        }

        private void LoadDevicesFromFile()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: File not found.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    Device device = ParseDevice(line);
                    if (device != null && devices.Count < maxCapacity)
                    {
                        devices.Add(device);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File read error: {ex.Message}");
            }
        }

        private Device ParseDevice(string line)
        {
            string[] parts = line.Split(',');

            if (parts.Length < 3)
            {
                Console.WriteLine($"Skipping line - wrong format: {line}");
                return null;
            }

            string id = parts[0];
            string name = parts[1];

            try
            {
                if (id.StartsWith("P"))
                {
                    bool isTurnedOn = bool.Parse(parts[2]);
                    string operatingSystem = parts.Length > 3 ? parts[3] : "no OS ";
                    return new PersonalComputer(id, name, isTurnedOn, operatingSystem);
                }
                else if (id.StartsWith("SW"))
                {
                    bool isTurnedOn = bool.Parse(parts[2]);
                    string batteryString = parts[3].Replace("%", "");
                    int battery = int.Parse(batteryString);
                    return new SmartWatch(id, name, isTurnedOn, battery);
                }
                else if (id.StartsWith("ED"))
                {
                    if (parts.Length < 4)
                    {
                        Console.WriteLine($"Skipping line  - Missing IP: {line}");
                        return null;
                    }

                    string ip = parts[2];
                    string network = parts[3];

                    return new EmbeddedDevice(id, name, false, ip, network);
                }

                Console.WriteLine($"Skipping line - wrong device: {line}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Skipping line - {ex.Message}");
                return null;
            }
        }

        public void ShowAllDevices()
        {
            Console.WriteLine("\nAll Devices:");
            foreach (var device in devices)
            {
                Console.WriteLine(device);
            }
        }

        public void TurnOnDevice(string id)
        {
            Device device = devices.Find(d => d.Id == id);
            if (device != null)
            {
                try
                {
                    device.TurnOn();
                    Console.WriteLine($"Device {id} is now ON.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Cannot turn on {device.Name}: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Device {id} not found.");
            }
        }

        public void TurnOffDevice(string id)
        {
            Device device = devices.Find(d => d.Id == id);
            if (device != null)
            {
                device.TurnOff();
                Console.WriteLine($"Device {id} turned off.");
            }
            else
            {
                Console.WriteLine($"Device {id} not found.");
            }
        }

        public void AddDevice(Device device)
        {
            if (devices.Count >= maxCapacity)
            {
                Console.WriteLine("Error: Cannot add device. Storage is full.");
                return;
            }

            devices.Add(device);
            Console.WriteLine($"Device {device.Id} added.");
            
            SaveToFile();
        }

        public void RemoveDevice(string id)
        {
            Device device = devices.Find(d => d.Id == id);
            if (device != null)
            {
                devices.Remove(device);
                Console.WriteLine($"Device {id} removed ({device.GetType().Name}).");
                SaveToFile();
            }
            else
            {
                Console.WriteLine($"Error: Device {id} not found.");
            }
        }

        public void EditDevice(string id, object newValue)
        {
            Device device = devices.Find(d => d.Id == id);
            if (device == null)
            {
                Console.WriteLine($"Error: Device {id} not found.");
                return;
            }

            Console.WriteLine($"Editing device: {device.Id}");

            if (device is PersonalComputer pc)
            {
                string newOS = (string)newValue;
                pc.OperatingSystem = newOS;
                Console.WriteLine($"Personal Computer {id} updated OS to {newOS}.");
            }
            else if (device is SmartWatch sw)
            {
                int newBattery = (int)newValue;
                sw.batteryPercentage = newBattery;
                Console.WriteLine($"SmartWatch {id} updated battery to {newBattery}%.");
            }
            else if (device is EmbeddedDevice ed)
            {
                string newNetwork = (string)newValue;
                ed.SetNetworkName(newNetwork);
                Console.WriteLine($"Embedded Device {id} updated network to {newNetwork}.");
            }
            SaveToFile();
        }
        public void SaveToFile()
        {
            try
            {
                List<string> lines = new List<string>();

                foreach (var device in devices)
                {
                    lines.Add(device.ToString());
                }

                File.WriteAllLines(filePath, lines);
                Console.WriteLine("saved.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"error {ex.Message}");
            }
        }

        public List<Device> GetDevices()
        {
            return devices;
        }
    }
}
