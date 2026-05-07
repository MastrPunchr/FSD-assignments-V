namespace IslandChess;
//Use BFS
public class KnightPath
{
    // We are given a start position and target position as input, the place where the knight is currently and the place it wants to go to. The chessboard is empty and the knight can go anywhere it wants to, as long as it moves like a knight and stays inside the chessboard (8x8).
    //
    // We want to find the minimum number of moves that the knight can make to reach the target. 
    //
    //For example: 
    //
    // Input: knightPosition: (1, 3) , targetPosition: (4,2)
    // Output: In 2 steps, the knight can reach the target
    //
    // Input: knightPosition: (1, 1) , targetPosition: (5, 6)
    // Output: In 3 steps, the knight can reach the target
    
    public void UserInput()
    {
        Console.WriteLine("FORMAT: x y\nBETWEEN: 1-8");
        Console.Write("Starting position: ");
        string startString = Console.ReadLine();
        Console.Write("Ending position: ");
        string endString = Console.ReadLine();

        try
        {
            int[] start = startString.Split(' ').Select(n => Convert.ToInt32(n)-1).ToArray();
            int[] end = endString.Split(' ').Select(n => Convert.ToInt32(n)-1).ToArray();
            Console.WriteLine($"In {MinKnightMoves(start, end)} steps, the knight can reach the target");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
    
    private int MinKnightMoves(int[] start, int[] end)
    {
        bool[,] board = new bool [8, 8];
        if (start[0] == end[0] && start[1] == end[1]) return 0;
        int[][] dirs = [[2, 1], [1, 2], [-1, 2], [-2, 1], [-2, -1], [-1, -2], [1, -2], [2, -1]];
        
        var path = new Queue<(int row, int col, int moves)>();
        path.Enqueue((start[0], start[1], 0));
        board[start[0], start[1]] = true;

        while (path.Count > 0)
        {
            var (row, col, moves) = path.Dequeue();
            if (row == end[0] && col == end[1])
            {
                return moves;
            }

            for (int i = 0; i < 8; i++)
            {
                int newRow = row + dirs[i][0];
                int newCol = col + dirs[i][1];

                if (IsValidCell(newRow, newCol, board))
                {
                    board[newRow, newCol] = true;
                    path.Enqueue((newRow, newCol, moves+1));
                }
            }
        }
        return -1;
    }
    
    private bool IsValidCell(int row, int col, bool[,] board)
    { 
        return row is >= 0 and < 8 && col is >= 0 and < 8 && !board[row, col];
    }
}