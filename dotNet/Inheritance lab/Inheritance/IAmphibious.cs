namespace Inheritance;

public interface IAmphibious : ISwimmable, IVehicleOperations
{
    void SwitchMode(string mode);
    string Mode { get; }

    void DisplayCapabilities()
    {
        Console.WriteLine($"Current mode: {Mode}");
    }
}