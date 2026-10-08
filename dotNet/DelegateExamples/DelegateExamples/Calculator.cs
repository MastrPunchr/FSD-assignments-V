namespace DelegateExamples;

public class Calculator
{
    public string Name { get; set; }
    public int CallCount { get; set; }

    public Calculator(string name)
    {
        Name = name;
    }

    public int Subtract(int a, int b)
    {
        CallCount++;
        return a - b;
    }

    public override string ToString() => $"Calculator {Name} (CallCount = {CallCount})";
}