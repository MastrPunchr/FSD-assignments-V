namespace Inheritance;

public interface IVehicleOperations
{
    string LicenseNumber { get; set; }

    void Register();

    void DisplayInfo()
    {
        Console.WriteLine($"Vehicle License: {LicenseNumber}");
    }

    bool IsValidLicense()
    {
        if (string.IsNullOrEmpty( LicenseNumber ) || LicenseNumber.Length >= 6)
        {
            return false;
        }
        return true;
    }

    static string GenLicenseNum()
    {
        return $"LIC{DateTime.Now.Ticks % 100000:D5}";
    }
}