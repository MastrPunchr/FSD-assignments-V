namespace temp;

public class banana
{
    public static int BananaCountGlobal = 0;
    public string Name { get; }
    private int Id { get; set; }
    private static Dictionary<int, int> _idCounts = new Dictionary<int, int>();

    public banana(int initCount, string name)
    {
        Random rand = new Random();
        int id = rand.Next();
        if(_idCounts.ContainsKey(id))
        {
            id = rand.Next();
        }
        _idCounts.Add(id, initCount);
        Name = name;
        Id = id;
    }

    public void AddBananas(int amount)
    {
        BananaCountGlobal += amount;
        _idCounts[Id] += amount;
    }

    public void RemoveBanana(int amount)
    {
        BananaCountGlobal -= amount;
        _idCounts[Id] -= amount;
    }
}