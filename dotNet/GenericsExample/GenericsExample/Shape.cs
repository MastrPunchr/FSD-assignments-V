namespace GenericsExample;

public interface IShape
{
    double Area();
}

public class Square(double side) : IShape
{
    public double Side { get; } = side;
    public double Area() => Side * Side;
}

public class Rectangle(double width, double height) : IShape
{
    public double Width { get; } = width;
    public double Height { get; } = height;
    public double Area() => Width * Height;
}

class Shape
{
    static double TotalArea<T>(List<T> shapes) where T : IShape
    {
        double sumAreas = 0;
        for (int i = 0; i < shapes.Count; i++)
        {
            sumAreas += shapes[i].Area();
        }

        return sumAreas;
    }

    static void Run()
    {
        Square s1 = new Square(5);
        Square s2 = new Square(3);
        List<Square> squares = new List<Square>{s1, s2};
        double totalArea = TotalArea(squares);
        Console.WriteLine(totalArea);
    }
}