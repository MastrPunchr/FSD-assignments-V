namespace temp;

class Program
{
    public static void Main(string[] args)
    {
        List<Shape> Shapes = new List<Shape>();
        Shapes.Add(new Circle("Circle1", "Green", 5));
        Shapes.Add(new Circle("Circle2", "Blue", 6));
        Shapes.Add(new Rectangle("Rect1", "Red", 5, 3));
        Shapes.Add(new Rectangle("Rect2", "Yellow", 6, 9));

        foreach (var shape in Shapes)
        {
            Console.WriteLine(shape);
        }
    }
}