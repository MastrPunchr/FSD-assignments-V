namespace Lab2;

public abstract class Character(string name, int health, int strength, int defense)
{
    public int Health = health; 
    public readonly int Strength = strength;
    public readonly int Defense = defense;

    public abstract void Attack(Character opponent);

    public void DisplayStats()
    {
        Console.WriteLine($"Name: {name}\nHealth: {Health}\nStrength: {Strength}\nDefense: {Defense}");
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    public string GetName()
    {
        return name;
    }
}
