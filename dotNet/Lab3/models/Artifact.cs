namespace Lab3;
public class Artifact : IItem
{
  public string Name { get; set; }
  public string Description { get; set; }
  public Artifact(string name, string description)
  {
    Name = name;
    Description = description;
  }
  public void Display()
  {
    Console.WriteLine($"Artifact name is {Name}. Description: {Description}");
  }
}