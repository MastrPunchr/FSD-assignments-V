namespace Lab2;

public class Enemy(string name)
    : Character(name, new Random().Next(20, 51), new Random().Next(3, 16), new Random().Next(0, 11))
{
    public override void Attack(Character opponent)
    {
        int attack = Strength - opponent.Defense;
        if (attack < 0)
            attack = 0;
        opponent.Health -= attack;
        Console.WriteLine($"{GetName()} deals {attack} damage to {opponent.GetName()}");
    }
}