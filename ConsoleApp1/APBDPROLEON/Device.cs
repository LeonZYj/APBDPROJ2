namespace APBDPROLEON;

public abstract class Device
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsTurnedOn { get; set; }

    public Device(string id, string name, bool isTurnedOn)
    {
        this.Id = id;
        this.Name = name;
        this.IsTurnedOn = isTurnedOn;
    }
    public abstract override string ToString();
}