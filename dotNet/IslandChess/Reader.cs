namespace IslandChess;

public class Reader(string filePath)
{
    private string FilePath { get; set; } = filePath;

    public int[][] ReadFile()
    {
        var lines = new List<int[]>();
        using (var reader = new StreamReader(FilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var row = new List<int>();
                foreach (char num in line)
                {
                    if (num == '1' || num == '0')
                    {
                        row.Add((int)char.GetNumericValue(num));
                    }
                }

                if (row.Count > 0)
                {
                    lines.Add(row.ToArray());
                }
            }

            return lines.ToArray();
        }
    }
}
