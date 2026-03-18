namespace OOPlesson;

public class Fairy
{
    private string name;
    private string colour;
    private int sparkleLevel;
    private bool isSuperFairy;

    public Fairy(string fairyName, string fairyColour)
    {
        this.name = fairyName;
        this.colour = fairyColour;
        Random rnd = new Random();
        this.sparkleLevel = rnd.Next(101);
        if (sparkleLevel <= 50)
            isSuperFairy = true;
        else
            isSuperFairy = false;
    }

    public override string ToString()
    {
        return $"Fairy name: {name}, Colour: {colour}, Sparkle Level: {sparkleLevel}, is a super fairy: {isSuperFairy}";
    }
}