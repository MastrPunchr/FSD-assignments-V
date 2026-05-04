namespace WonkaMaze;

public class Reader
{
    protected string FilePath { get; set; }
    
    private readonly List<string> _lines;
    public List<List<bool>> Map { get; private set; }

    public Reader(string filePath)
    {
        FilePath = filePath;
        Map = new List<List<bool>>();
        _lines = new List<string>();
        ReadFile();
    }

    private List<List<bool>> ReadFile()
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

            foreach (string line in _lines)
            {
                List<bool> newLine = new List<bool>();
                foreach (char num in line)
                {
                    if (num == 1)
                    {
                        newLine.Add(true);
                    } else if (num == 0)
                    {
                        newLine.Add(false);
                    }
                }
                Map.Add(newLine);
            }
            return Map;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}
