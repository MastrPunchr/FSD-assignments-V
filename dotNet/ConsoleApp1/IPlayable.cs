namespace ConsoleApp1;

public interface IPlayable
{
    public void Play()
    {
        Console.WriteLine("track is playing");
    }

    public void Pause()
    {
        Console.WriteLine("Track is paused");
    }
}