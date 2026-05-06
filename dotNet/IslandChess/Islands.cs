namespace IslandChess;

public class Islands
{
    private int _islandCount { get; set; }
    private int[][] _map { get; set; }
    private bool[][] _visited{ get; set; }

    public void MapPathing(string fileName)
    {
        _islandCount = 0;
        
        //shorter declaration of a reader
        _map = new Reader($"../../../{fileName}").ReadFile();
        
        //tandem matrix of booleans to verify if a cell has been visited or not
        _visited = new bool[_map.Length][];

        for (int i = 0; i < _map.Length; i++)
        {
            //sets the length of each row of booleans in the tandem matrix so that it lines up all nice and dandy with the map's matrix
            _visited[i] = new bool[_map[i].Length];
        }
        

        for(int i = 0; i < _map.Length; i++)
        {
            for(int j = 0; j < _map[i].Length; j++)
            {
                if (_map[i][j] != 1 || _visited[i][j]) continue;
                _islandCount++;
                IslandDFS(i, j);
            }
        }
        
        Console.WriteLine($"There are {_islandCount} islands.");
    }

    private void IslandDFS(int row, int col)
    {
        _visited[row][col] = true;

        int[][] directions = new int[][]
        {
            //figured out collection expressions and wow it's quicker to type
            [0, 1], [1, 1], [1, 0], [1, -1], [0, -1], [-1, -1], [-1, 0], [-1, 1]
        };

        foreach (var dir in directions)
        {
            int newRow = row + dir[0];
            int newCol = col + dir[1];

            if (IsValidCell(newRow, newCol) && _map[newRow][newCol] == 1 && !_visited[newRow][newCol])
            {
                IslandDFS(newRow, newCol);
            }
        }
    }
    
    private bool IsValidCell(int row, int col)
    { 
        return row >= 0 && row < _map.Length && col >= 0 && col < _map[row].Length;
    }
}