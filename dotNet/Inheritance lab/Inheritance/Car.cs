namespace Inheritance;

public class Car : Vehicle 
{
    public int DoorCount { get; set; }

    public Car(string brand, int year, int doors) : base(brand, year)
    {
        DoorCount = doors;
    }

    public override void StartEngine()
    {
        Console.WriteLine($"{Brand} car is starting");
    }

    public override void Stop()
    {
        Console.WriteLine($"{Brand} car stops with the brake pedal");
    }
}