using System.Globalization;
namespace Merging;
public class Program
{
    public static void Main()
    {
        string format = "yyyy-MM-dd HH:mm";
        FileManager writer = new FileManager("output.txt");
        List<string> read1 = new FileManager("person1.txt").ReadFile();
        List<string> read2 = new FileManager("person2.txt").ReadFile();
        SortedList<DateTime, string> messages = new SortedList<DateTime, string>();
        for (int i = 1; i <= ((read1.Count) + (read2.Count)); i++)
        {
            string[] str;
            if (i <= read1.Count)
            {
                str = read1[i - 1].Split("  ");
                str[1] = $"Person 1: {str[1]}";
            }
            else
            {
                str = read2[i - read1.Count - 1].Split("  ");
                str[1] = $"Person 2: {str[1]}";
            }
            DateTime date = DateTime.ParseExact(str[0], format, CultureInfo.InvariantCulture);
            messages.Add(date, str[1]);
        }
        foreach (KeyValuePair<DateTime, string> kvp in messages)
        {
            writer.WriteContent(kvp.Value);
        }
    }
}