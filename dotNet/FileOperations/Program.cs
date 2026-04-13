namespace FileOperations
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Reading from a file
            FileReader reader = new FileReader("/Users/valkyrie/Documents/Assignments/dotNet/FileOperations/FileOperations/file.txt");
            reader.ReadFile();
            reader.DisplayCount();
            reader.GetLines();
            
            //Writing to a fuckass file
            FileWriter writer = new FileWriter("/Users/valkyrie/Documents/Assignments/dotNet/FileOperations/FileOperations/output.txt");
            Console.WriteLine($"File exists: {writer.FileExists()}");
            writer.WriteContent("Fuck you");
        }
    }
    
    //use DateTime.ParseExact
}