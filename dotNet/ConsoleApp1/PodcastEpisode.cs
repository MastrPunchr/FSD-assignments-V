namespace ConsoleApp1;

public class PodcastEpisode : Track
{
    public string GuestSpeaker { get; set; }
    public PodcastEpisode(string title, string artist, int duration, string guestSpeaker) : base(title, artist, duration)
    {
        GuestSpeaker = guestSpeaker;
    }

    public override string GetDetails()
    {
        return $"Podcast: {Title} | Guest: {GuestSpeaker} | Duration: {Duration}s";
    }
}