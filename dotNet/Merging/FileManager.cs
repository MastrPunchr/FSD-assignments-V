namespace Merging;

public class FileManager
{
    protected string FilePath { get; set; }
    private readonly List<string> _lines;

    public FileManager(string filePath)
    {
        FilePath = $"../../../{filePath}";
        _lines = new List<string>();
    }
    //check if users can just call a line like this instead of implementing a FileExists function
    //File.Exists(FilePath);
    public List<string> ReadFile()
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
            return _lines;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

    public void WriteContent(string content)
    {
        WriteContent(new List<string> { content });
    }
    
    public void WriteContent(List<string> lines)
    {
        try
        {
            using (var writer = new StreamWriter(FilePath, true))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
            }
            Console.WriteLine($"Wrote {lines.Count} lines to file");
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}