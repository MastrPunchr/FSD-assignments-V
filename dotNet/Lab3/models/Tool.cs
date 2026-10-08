namespace Lab3;
public class Tool : IUsable, IItem, ICategorizable
{
  public string Name { get; set; }
  public string Description { get; set; }
  public string Category { get; set; }
  public Tool(string name, string description, string category)
  {
    Name = name;
    Description = description;
    Category = category;
  }
  public virtual void Display()
  {
    Console.WriteLine($"Tool name: {Name}. Description: {Description}. Category: {Category}");
  }
  public virtual void Use()
  {
    Console.WriteLine($"Using tool {Name}");
  }
}