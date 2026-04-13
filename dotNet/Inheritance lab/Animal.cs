namespace Inheritance;

public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void MakeSound()
    {
        Console.WriteLine($"{Name} makes a sound");
    }

    public void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping");
    }

    public virtual void Move()
    {
        Console.WriteLine($"{Name} is moving");
    }
}