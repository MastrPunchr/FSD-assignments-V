namespace FairiesToFairies;

class Program
{
    public static void Main()
    {
        //TEST 1: Test Fairy class
        //TEST 1.1: Test basic fairy
        Fairy fairy = new Fairy("basic", 150, 30);
        Console.WriteLine(fairy);
        Console.WriteLine(fairy.CastSpell());
        Console.WriteLine(fairy.Fly());
        Console.WriteLine(fairy.UseDust()); //Fairy dust tests were moved to be part of the fairy test as it made more sense for it to be here to chek that the fairy dust assignment in fairy.cs works

        //TEST 1.2: Test super fairy
        Fairy superFairy = new Fairy("super", 150, 45);
        Console.WriteLine(superFairy);
        Console.WriteLine(superFairy.CastSpell());
        Console.WriteLine(superFairy.Fly());
        Console.WriteLine(superFairy.UseDust());
        
        //TEST 2: Test FairyDust class
        FairyDust ourple = new FairyDust("Ourple", 99); //Ourple is an intentional type
        Console.WriteLine(ourple);
        Console.WriteLine(ourple.UseDust());
        Console.WriteLine(FairyDust.DescribeTotalDust()); //This should display 3 seeing as it will count ourple as well as the dust created by the basic and super fairies.
        
        //TEST 3: Test EnchantedItem class
        EnchantedItem excalibur = new EnchantedItem("Excalibur", 100, superFairy);
        Console.WriteLine(excalibur);
        Console.WriteLine(excalibur.DeactivateEnchantment());
        Console.WriteLine(excalibur.DeactivateEnchantment());
        Console.WriteLine($"Is activated: {excalibur.IsActivated}");
    }
}