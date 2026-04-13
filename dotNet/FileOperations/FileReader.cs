namespace FileOperations;

public class FileReader : FileManager
{
    private readonly List<string> _lines;

    public FileReader(string filePath) : base(filePath)
    {
        _lines = new List<string>();
    }

    public void ReadFile()
    {
        try
        {
            using (var reader = new StreamReader(FilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    _lines.Add(line);
                }
            }
            Console.WriteLine($"Read {_lines.Count} lines from file");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void DisplayCount()
    {
        foreach (string line in _lines)
        {
            Console.WriteLine(line);
        }
    }

    public List<string> GetLines() => _lines;

}