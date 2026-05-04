namespace WonkaMaze;
public class Maze
{
    public int[,] MazeData;
    public bool[,] Visited;
    public Stack<(int, int)> Path;
    public int Rows, Cols;
    public Maze(string mazeAddress) 
    {
        StreamReader sr = new StreamReader(mazeAddress);
        string line = sr.ReadLine();
        List<string[]> rows = new List<string[]>();

        while (line != null) // Read all rows first
        {
            string[] row = line.Split(",");
            rows.Add(row);
            line = sr.ReadLine();
        }
        sr.Close();

        Rows = rows.Count;
        Cols = rows[0].Length;
        MazeData = new int[Rows, Cols];
        Visited = new bool[Rows, Cols];

        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Cols; col++)
            {
                MazeData[row, col] = Int16.Parse(rows[row][col]);
                Visited[row, col] = false;
            }
        }
    }

    public Stack<(int, int)> SolveMaze()
    {
        Path = new Stack<(int, int)>();
        Path.Push((0, 0));
        Visited[0, 0] = true;
        while (Path.Count > 0)
        {
            (int, int) current = Path.Peek();
            // Check if Destination
            if(Rows == current.Item1 + 1 && Cols == current.Item2 + 1)
            {
                return Path;
            }
            // Check left
            if (current.Item2 > 0 && CanMove((current.Item1, current.Item2 - 1)))
            {
                Path.Push((current.Item1, current.Item2 - 1));
                Visited[current.Item1, current.Item2 - 1] = true;
            }
            // Check up
            else if (current.Item1 > 0 && CanMove((current.Item1 - 1, current.Item2)))
            {
                Path.Push((current.Item1 - 1, current.Item2));
                Visited[current.Item1 - 1, current.Item2] = true;
            }
            // Check right
            else if (current.Item2 + 1 < Cols && CanMove((current.Item1, current.Item2 + 1)))
            {
                Path.Push((current.Item1, current.Item2 + 1));
                Visited[current.Item1, current.Item2 + 1] = true;
            }
            // Check down
            else if (current.Item1 + 1 < Rows && CanMove((current.Item1 + 1, current.Item2)))
            {
                Path.Push((current.Item1 + 1, current.Item2));
                Visited[current.Item1 + 1, current.Item2] = true;
            }
            // Else case // no way to go, dead end.
            else
            {
                Path.Pop();
            }
        }
        return null;
    }
    public bool CanMove((int, int) nextMove)
    {
        // check if valid
        if (MazeData[nextMove.Item1, nextMove.Item2] == 1 && !Visited[nextMove.Item1, nextMove.Item2])
        {
            return true;
        }
        return false;
    }

    public void PrintPath()
    { // Print the stack like a path: 1 -> 2 -> 3 -> Finish.
        Stack<(int, int)> reverse = new Stack<(int, int)>();
        if (Path is null)
        {
            Console.WriteLine("Ophelia, I couldn't find you a path :`(");
            return;
        }
        else
        {
            Console.WriteLine("Ophelia, I found you a path!");
            Console.Write("The path: ");
        }
        // Start the while loop and reverse it.
        while (Path.Count > 0)
        {
            (int, int) temp = Path.Pop();
            reverse.Push(temp);
            // reverse.Push(path.Pop());
        }
        while (reverse.Count > 0)
        {
            (int, int) temp = reverse.Pop();
            Path.Push(temp);
            Console.Write($"{temp} -> ");
            if (reverse.Count == 0)
            {
                Console.Write($"Tadaaa!");
            }
        }
    }
}