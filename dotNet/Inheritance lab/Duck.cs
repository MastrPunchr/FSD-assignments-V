namespace Inheritance;

public class Duck : Animal, IFlyable, ISwimmable
{
    public int MaxAltitude { get; set; }
    public int MaxDepth { get; set; }
    public double SwimSpeed { get; set; }

    public Duck(string name, int age) : base(name, age)
    {
        MaxAltitude = 300;
        SwimSpeed = 5.0;
        MaxDepth = 10;
    }

    public void TakeOff()
    {
        Console.WriteLine("Duck taking off");
    }

    public void Land()
    {
        Console.WriteLine("Duck is landing");
    }

    public void Fly(int altitude)
    {
        if (altitude > MaxAltitude)
        {
            Console.WriteLine("Cannot fly that high");
        }
        else
        {
            Console.WriteLine($"{Name} is flying at {altitude}m altitude");
        }
    }

    public void Swim()
    {
        Console.WriteLine($"{Name} is swimming around at {SwimSpeed}km/h");
    }

    public void Dive(int depth)
    {
        if (depth > MaxDepth)
        {
            Console.WriteLine("Ducks cannot swim that deep");
        }
        else
        {
            Console.WriteLine($"{Name} is now swimming at {depth}m deep");
        }
    }

    public override void MakeSound()
    {
        Console.WriteLine($"Got any grapes?");
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} is waddling around");
    }
}