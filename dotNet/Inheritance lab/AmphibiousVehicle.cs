namespace Inheritance;

public class AmphibiousVehicle : Vehicle, IAmphibious
{
    private string currentMode = "land";
    public string Mode => currentMode;
    public double SwimSpeed { get; set; }
    public string LicenseNumber { get; set; }
    public bool HasAutoPilot { get; set; }

    public AmphibiousVehicle(string brand, int year) : base(brand, year)
    {
        SwimSpeed = 10;
        LicenseNumber = IVehicleOperations.GenLicenseNum();
        HasAutoPilot = false;
    }

    public override void StartEngine()
    {
        Console.WriteLine($"{Brand} amphibious vehicle engine starts (Mode: {Mode})");
    }

    void ISwimmable.Swim()
    {
        if (currentMode.ToLower() != "water")
        {
            Console.WriteLine("Cannot swim in land mode! Switch to water mode first");
            return;
        }
        Console.WriteLine($"{Brand} vehicle is swimming at {SwimSpeed}km/h");
    }
    
    void ISwimmable.Dive(int depth)
    {
        Console.WriteLine($"{Brand} is a boat, how is it gonna dive you dope");
    }

    public void SwitchMode(string mode)
    {
        if (mode.ToLower() == "water" || mode.ToLower() == "land")
        {
            currentMode = mode.ToLower();
            Console.WriteLine($"{Brand} switched to {currentMode} mode");
        }
        else
        {
            Console.WriteLine("Invalid mode! Use 'water' or 'land'");
        }
    }

    public void Register()
    {
        Console.WriteLine($"{Brand} amphibious vehicle registered: {LicenseNumber}");
    }

    public void EnableAutopilot()
    {
        Console.WriteLine($"{Brand} amphibious vehicle doesn't support autopilot");
    }
    
    public void DisableAutopilot()
    {
        Console.WriteLine($"{Brand} amphibious vehicle doesn't support autopilot");
    }
}