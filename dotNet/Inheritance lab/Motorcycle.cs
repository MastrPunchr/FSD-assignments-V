namespace Inheritance;

public class Motorcycle : Vehicle
{
    public bool HasSideCar { get; set; }

    public Motorcycle(string brand, int year, bool hasSideCar) : base(brand, year)
    {
        HasSideCar = hasSideCar;
    }

    public override void StartEngine()
    {
        Console.WriteLine($"{Brand} motorcycle engine is banging, uh oh");
    }
}