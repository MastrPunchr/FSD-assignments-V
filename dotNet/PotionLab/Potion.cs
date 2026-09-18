namespace PotionLab;
public class Potion
{
    public string PotionType { get; set; }
    public string Potency { get; set; }
    public int PotionId { get; }
    public static int PotionCount;
    private static int[] _idList;

    public Potion(string type, string potency)
    {
        PotionType = type;
        Potency = potency;
        PotionCount++;

        Random rand = new Random();
        int id = rand.Next();
        while (_idList.Contains(id))
        {
            id = rand.Next();
        }
        PotionId = id;
    }

    public string DescribePotion()
    {
        return $"Potion type: {PotionType}\nPotency: {Potency}\nPotion ID: {PotionId}";
    }

    public string UsePotion()
    {
        string effect;
        if (PotionType == "Invisibility")
        {
            effect = "invisible";
        } else if (PotionType == "Poison")
        {
            effect = "poisoned";
        }
        else
        {
            effect = "healing";
        }

        PotionCount--;
        return $"Glug glug glug, you are now {effect}!";
    }

    public static int GetTotalPotions()
    {
        return PotionCount;
    }

    public int GetPotionId()
    {
        return PotionId;
    }
}