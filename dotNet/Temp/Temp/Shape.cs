namespace temp;

public abstract class Shape
{
    public string Name { get; set; }
    public string Colour { get; set; }

    public Shape(string name, string colour)
    {
        Name = name;
        Colour = colour;
    }

    public abstract double CalculateArea();

    public override string ToString()
    {
        return $"Name: {Name}, Colour: {Colour}, Area: {CalculateArea():F2}";
    }
}

public class Circle : Shape
{
    private double _radius;

    public double Radius
    {
        get => _radius;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Radius must be positive");
            _radius = value;
        }
    }

    public Circle(string name, string colour, double radius) : base(name, colour)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Rectangle : Shape
{
    private double _width;
    private double _length;
    public double Width
    {
        get => _width;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Width must be positive");
            _width = value;
        }
    }

    public double Length
    {
        get => _length;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Length must be positive");
            _length = value;
        }
    }

    public Rectangle(string name, string colour, double width, double length) : base(name, colour)
    {
        Length = length;
        Width = width;
    }

    public override double CalculateArea()
    {
        return Length * Width;
    }
}