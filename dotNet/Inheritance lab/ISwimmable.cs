namespace Inheritance;

public interface ISwimmable
{
    double SwimSpeed { get; set; }

    void Swim();
    void Dive(int depth);
}