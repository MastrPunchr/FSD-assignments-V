namespace Lab3;
public class Wand : Tool, IMagical
{
  public int MagicPower { get; set; }
  public Wand(string name, string description, string category) : base(name, description, category)
  {
    MagicPower = 100;
  }
  public override void Display()
  {
    Console.WriteLine($"Wand name: {Name}. Description: {Description}. Category: {Category}. Magic Power: {MagicPower}");
  }
  public override void Use()
  {
    if (MagicPower >= 25)
    {
      MagicPower -= 25;
      Console.WriteLine($"Wand {Name} cast a spell using 25 magic power!");
    }
    else
    {
      Console.WriteLine($"Too little magic power, you only have {MagicPower}!");
    }
  }
  public void Recharge()
  {
    MagicPower = 100;
    Console.WriteLine($"Wand recharged to {MagicPower}");
  }
}