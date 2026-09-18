namespace Lab2;

public class Warrior(string name) : Character(name, health: 100, strength: 15, defense: 5)
{
    public override void Attack(Character opponent)
    {
        int attack = Strength - opponent.Defense;
        if (attack < 0)
            attack = 0;
        attack += 2;
        opponent.Health -= attack;
        Console.WriteLine($"{GetName()} deals {attack} damage to {opponent.GetName()}");
    }

    public void Heal()
    {
        Health += 10;
        Console.WriteLine($"10 health restored");
    }
}