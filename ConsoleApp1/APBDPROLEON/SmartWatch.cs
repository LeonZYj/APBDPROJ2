namespace APBDPROLEON
{
    public class SmartWatch : Device, IPowerNotifier
    {
        private int batteryPercentage;
        private bool lowOnBattery;

        public SmartWatch(string id, string name, bool isTurnedOn, int batteryPercentage)
            : base(id, name, isTurnedOn)
        {
            if (batteryPercentage < 0 || batteryPercentage > 100)
                throw new ArgumentException("Battery percentage must be between 0 and 100.");

            this.batteryPercentage = batteryPercentage;
            lowOnBattery = batteryPercentage < 20;

            if (lowOnBattery)
            {
                NotifyLowPower();
            }
        }

        public override void TurnOn()
        {
            if (batteryPercentage < 11)
                throw new EmptyBatteryException($"Cannot turn on {Name}: Battery is below 11%.");

            IsTurnedOn = true;
            batteryPercentage -= 10;
            lowOnBattery = batteryPercentage < 20;

            if (lowOnBattery)
            {
                NotifyLowPower();
            }

            Console.WriteLine($"{Name} is now turned on. Battery remaining: {batteryPercentage}%.");
        }

        public void TurnOff()
        {
            IsTurnedOn = false;
            Console.WriteLine($"{Name} has been turned off.");
        }

        public void NotifyLowPower()
        {
            Console.WriteLine($"⚠ Warning: {Name} has low battery ({batteryPercentage}%)!");
        }

        public override string ToString()
        {
            return $"[SmartWatch] ID: {Id}, Name: {Name}, IsTurnedOn: {IsTurnedOn}, Battery: {batteryPercentage}%";
        }
    }

    public class EmptyBatteryException : Exception
    {
        public EmptyBatteryException(string message) : base(message) { }
    }
}