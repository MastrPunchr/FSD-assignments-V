namespace ConsoleApp1;

public class Song : Track
{

    public string Genre { get; set; }
    public Song(string title, string artist, int duration, string genre) : base(title, artist, duration)
    {
        Genre = genre;
    }

    public override string GetDetails()
    {
        return $"Song: {Title} | Genre: {Genre} | Duration: {Duration}s";
    }
}