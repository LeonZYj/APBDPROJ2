namespace APBDPROLEON;

public class SmartWatch : Device, IPowerNotifier
{
    private int batteryPercentage;
    private bool lowOnBattery;

    public SmartWatch(string id, string name, bool isTurnedOn, int batteryPercentage)
        : base(id, name, isTurnedOn)
    {
        if (batteryPercentage > 100 || batteryPercentage < 0)
            throw new ArgumentException("Battery has to be in bounds [0;100]");
        
        this.batteryPercentage = batteryPercentage;
        lowOnBattery = batteryPercentage< 20;

        if (lowOnBattery)
        {
            NotifylowPower();
        }
    }


    public void NotifylowPower()
    {
        Console.WriteLine($"$our smartWatch has low battery : {Name}, battery percentage: {batteryPercentage}%");
    }
    public override string ToString()
    {
        return $"SmartWatch: {Id}, name: {Name}, isDeviceTurnedOn: {IsTurnedOn}, batteryPercentage: {batteryPercentage}";
    }
}

