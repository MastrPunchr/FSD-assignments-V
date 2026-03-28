namespace Inheritance;

public abstract class Vehicle
{
    public string Brand { get; set; }
    public int Year { get; set; }

    public Vehicle(string brand, int year)
    {
        Brand = brand;
        Year = year;
    }

    public abstract void StartEngine();

    public virtual void Stop()
    {
        Console.WriteLine($"{Brand} vehicle is stopping");
    }

    public void Honk()
    {
        Console.WriteLine($"{Brand} honks");
    }
}