namespace Inheritance;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("====== C# Inheritance ======");
        
        Console.WriteLine("1. Basic Inheritance");
        Animal animal = new Animal("Generic Animal", 5);
        animal.MakeSound();
        animal.Sleep();
        animal.Move();
        
        Console.WriteLine("2. Method Overriding");
        Dog dog = new Dog("Rufus", 3, "dalmatian");
        dog.MakeSound();
        dog.Sleep();
        dog.Move();
        dog.Fetch();
        Console.WriteLine($"Breed: {dog.Breed}");
        dog.Breed = "Labrador";

        Car car = new Car("FuckYou", 99999999, 1);
        car.StartEngine();
        car.Stop();

        Motorcycle bike = new Motorcycle("Yamaha", 2024, false);
        bike.StartEngine();
        bike.Stop();

        Animal[] animals =
        {
            new Animal("Wild Boar", 2),
            new Dog("Krypto", 1000, "Kryptonian"),
            new ServiceDog("Fido", 5, "Beagle", "Search and Rescue")
        };

        foreach (Animal a in animals)
        {
            a.MakeSound();
        }

        Vehicle[] vehicles = { car, bike };
        foreach (Vehicle v in vehicles)
        {
            v.StartEngine();
            v.Honk();
            v.Stop();
        }

        Duck duck = new Duck("the duck", 80);
        duck.MakeSound();
        duck.TakeOff();
        duck.Fly(500);
        duck.Land();
        duck.Swim();
        duck.Dive(4);
        duck.Move();

        AmphibiousVehicle boat = new AmphibiousVehicle("Frog", 518136);
        
        boat.StartEngine();
        boat.Register();
        boat.SwitchMode("water");

        ISwimmable amphibiousSwimmer = boat;
        boat.SwitchMode("Land");
    }
}