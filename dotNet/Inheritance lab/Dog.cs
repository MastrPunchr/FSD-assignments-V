namespace Inheritance;

public class Dog : Animal
{
    public string Breed { get; set; }
    
    public Dog(string name, int age, string breed) : base(name, age)
    {
        Breed = breed;
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} is barking: Woof, woof");
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} runs on four legs");
    }

    public void Fetch()
    {
        Console.WriteLine($"{Name} is fetching the ball");
    }
}