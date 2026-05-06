namespace ConsoleApp1;

public abstract class Track : IPlayable
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public int Duration { get; set; }

    public Track(string title, string artist, int duration)
    {
        Title = title;
        Artist = artist;
        Duration = duration;
    }

    public void Play(){}

    public void Pause(){}

    public abstract string GetDetails();
}