namespace RNACellFinder;

public class CellFinder
{
    public static void ValidCells()
    {
        List<int[]> table = new List<int[]>();
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("Enter a row of numbers separated by commas (leave empty to continue):");
            string userInput = Console.ReadLine();
            if (userInput == "")
            {
                quit = true;
                continue;
            }
            List<int> inputs = new List<int>();
            bool isValid = true;
            foreach (string str in userInput.Split(","))
            {
                int num;
                try
                {
                    num = Convert.ToInt16(str);
                }
                catch
                {
                    isValid = false;
                    break;
                }
                inputs.Add(num);
            }
            if(isValid) table.Add(inputs.ToArray());
            else Console.WriteLine("Invalid row input"); 
        }

        try
        {
            int[] seats = new int[table.Count];
            seats[0] = 0;
            seats[^1] = 0;

            for (int i = 1; i < table.Count - 1; i++)
            {
                seats[i] = 0;
                for (int j = 1; j < table[i].Length - 1; j++)
                {
                    int up = table[i - 1][j];
                    int down = table[i + 1][j];
                    int left = table[i][j - 1];
                    int right = table[i][j + 1];
                    int cur = table[i][j];

                    if ((up > cur && down > cur && left < cur && right < cur) ||
                        (up < cur && down < cur && left > cur && right > cur))
                    {
                        seats[i]++;
                    }
                }
            }

            if (seats.Max() == 0)
            {
                Console.WriteLine("There are 0 valid seats");
                return;
            }
            for (int i = 0; i < table.Count; i++)
            {
                Console.WriteLine($"Row {i + 1}: {seats[i]} Seatable Cells");
            }
            
            int maxRow = 0;
            foreach (int row in seats)
            {
                if (seats.Max() == row)
                {
                    maxRow = row + 1;
                }
            }
            Console.WriteLine($"Row with Most Seatable Cells: Row {maxRow} with {seats.Max()} seatable cells.");
        }
        catch
        {
            Console.WriteLine("Okay fine just don't enter anything then chud");
        }
    }
}