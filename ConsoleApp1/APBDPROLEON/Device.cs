namespace APBDPROLEON;

public abstract class Device
{
    public string id { get; set; }
    public string name { get; set; }
    public bool isDeviceTurnedOn { get; set; }

    public Device(string id, string name, bool isDeviceTurnedOn)
    {
        this.id = id;
        this.name = name;
        this.isDeviceTurnedOn = isDeviceTurnedOn;
    }

    public abstract void TurnOn();
    public abstract override string ToString();
}