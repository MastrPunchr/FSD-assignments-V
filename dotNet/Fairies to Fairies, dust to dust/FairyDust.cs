namespace FairiesToFairies;

public class FairyDust
{
    private int _sparkleLevel;
    private string _colour;
    private static int _totalDustCreated;

    public FairyDust(string color, int sparkleLevel)
    {
        _colour = color;
        _sparkleLevel = sparkleLevel;
        _totalDustCreated++;
    }

    public string UseDust()
    {
        return $"Using {_colour} dust with sparkle level {_sparkleLevel}";
    }

    //DescribeDust class was removed as it was a redundant function that had the same purpose as the ToString override
    
    public static string DescribeTotalDust() //Static because it is describing how many you have made in total, silly
    {
        return $"Total fairy dust created: {_totalDustCreated}";
    }
    public override string ToString()
    {
        return $"Colour: {_colour}, Sparkle level: {_sparkleLevel}";
    }
}
