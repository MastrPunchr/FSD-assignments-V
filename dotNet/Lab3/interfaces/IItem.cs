namespace Lab3;
public interface IItem
{
  public string Name { get; set; }
  public string Description { get; set; }
  public void Display();
}