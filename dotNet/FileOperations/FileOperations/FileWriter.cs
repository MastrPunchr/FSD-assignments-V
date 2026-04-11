namespace FileOperations;

public class FileWriter : FileManager
{
    public FileWriter(string path) : base(path){}

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