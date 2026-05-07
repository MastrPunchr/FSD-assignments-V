namespace IslandChess;
class Program
{
    public static void Main()
    {
        Islands map = new Islands();
        map.MapPathing("Islands.txt");

        KnightPath path = new KnightPath();
        path.UserInput();
    }
}