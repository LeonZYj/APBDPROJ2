namespace APBDPROLEON
{
    public class SmartWatch : Device, IPowerNotifier
    {
        public BAtteryPercentageFunctionality batteryBattery { get; private set; }

        public SmartWatch(string id, string name, bool isTurnedOn, int batteryPercentage)
            : base(id, name, isTurnedOn)
        {
            batteryBattery = new BAtteryPercentageFunctionality(batteryPercentage);
            if (batteryBattery.isLowOnBattery())
            {
                NotifyLowPower();
            }
        }

        public override void TurnOn()
        {
            if (batteryBattery.smallerThen11())
            {
                throw new EmptyBatteryException($"Cant turn on {Name} with battery lower then 11%");
            }

            IsTurnedOn = true;
            batteryBattery.BatterMinus10();

            if (batteryBattery.isLowOnBattery())
            {
                NotifyLowPower();
            }

            Console.WriteLine($"{Name} is turrned on with battery {batteryBattery.GetBatteryLevel()}%");
        }


        public void NotifyLowPower()
        {
            Console.WriteLine($"Warning: {Name} has low battery with battery {batteryBattery.GetBatteryLevel()}%");
        }


        public override string ToString()
        {
            return
                $"[SmartWatch] ID: {Id}, Name: {Name}, IsTurnedOn: {IsTurnedOn}, Battery: {batteryBattery.GetBatteryLevel()}%";
        }

        public void SetBatteryLevel(int value)
        {
            batteryBattery.SetBatteryLevel(value);
        }
    }
}