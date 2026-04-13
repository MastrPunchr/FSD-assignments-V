namespace FileOperations;

public class FileManager
{ 
    protected string FilePath { get; set; }

    public FileManager(string filePath)
    {
        FilePath = filePath;
    }

    public bool FileExists()
    {
        return File.Exists(FilePath);
    }
}