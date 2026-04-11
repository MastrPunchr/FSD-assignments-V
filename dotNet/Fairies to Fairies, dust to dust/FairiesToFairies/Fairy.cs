namespace FairiesToFairies;

public class Fairy
{
    private string _name;
    private int _age;
    private int _magicLevel;
    private FairyDust _dust;
    
    public Fairy(string name, int age, int magicLevel)
    {
        _name = name;
        _age = age;
        _magicLevel = magicLevel;
        Random rnd = new Random();
        
        switch (_magicLevel)
        {
            case > 40:
                _dust = new FairyDust("Gold", rnd.Next(21, 51));
                break;
            case <= 40:
                _dust = new FairyDust("Blue", rnd.Next(1, 21));
                break;
        }
    }

    public string CastSpell()
    {
        switch(_magicLevel)
        {
            case > 40:
                return $"{_name} casts a super magical spell!";
            case <= 40:
                return $"{_name} casts a basic spell.";
        }
    }

    public string Fly()
    {
        return $"{_name} is flying!";
    }

    public string UseDust()
    {
        return _dust.UseDust();
    }

    public override string ToString()
    {
        return $"{_name}, Age: {_age}, Magic Level: {_magicLevel}, Dust: ({_dust})";
    }
}
