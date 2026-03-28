namespace Inheritance;

public interface IAdvancedVehicle : IVehicleOperations
{
    bool HasAutoPilot { get; set; }

    void EnableAutoPilot();
    void DisableAutoPilot();
    void PerformSelfDiagnostic()
    {
        Console.WriteLine("Performing self-diagnostic...");
        if (IsValidLicense())
        {
            Console.WriteLine("License validaiton passed");
        }
        Console.WriteLine($"Autopilot: {HasAutoPilot}");
    }
}