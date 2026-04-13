namespace Inheritance;

public class ServiceDog : Dog
{
    public string Job { get; set; }

    public ServiceDog(string name, int age, string breed, string job) : base(name, age, breed)
    {
        Job = job;
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} is working: WOOF! I'm working!");
    }

    public void Work()
    {
        Console.WriteLine("Service dog is working");
    }
}