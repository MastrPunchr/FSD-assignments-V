namespace Lab3;
public class Grimoire : IMagical, IItem
{
  public string Name { get; set; }
  public string Description { get; set; }
  public int MagicPower { get; set; }
  public Grimoire(string name, string description)
  {
    Name = name;
    Description = description;
    MagicPower = 1;
  }
  public void Display()
  {
    Console.WriteLine($"Grimoire name: {Name}. Description: {Description}. Magic Power: {MagicPower}");
  }
  public void Recharge()
  {
    MagicPower = 1;
    Console.WriteLine($"Grimoire recharged to {MagicPower}");
  }
  public void Use()
  {
    if (MagicPower > 0)
    {
      MagicPower--;
      Console.WriteLine($"Grimoire {Name} was read using 1 magic power!");
    }
    else
    {
      Console.WriteLine("Not enough magic power, you must recharge!");
    }
  }
}