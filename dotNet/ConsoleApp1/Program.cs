namespace ConsoleApp1;

class Program {
    static void Main(string[] args)
    {
        Song a = new Song("a", "a", 2, "a");
        PodcastEpisode b = new PodcastEpisode("b", "b", 2, "b");
        a.Play();
        a.Pause();
        b.Play();
        b.Pause();

        List<Track> tracks = new List<Track>();
        tracks.Add(a);
        tracks.Add(b);

        foreach (Track track in tracks)
        {
            Console.WriteLine(track.GetDetails());
        }
    }
}