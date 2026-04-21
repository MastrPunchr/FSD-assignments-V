namespace CineManager;

public class Theatre
{
    public int ID { get; }
    public bool HasRecliners { get; set; }
    public string TheatreType { get; set; }
    public List<Movie> Movies { get; private set; }

    public Theatre(int id, bool recliners, string theatreType)
    {
        ID = id;
        HasRecliners = recliners;
        SetTheatreType(theatreType);
        Movies = new List<Movie>();
    }

    public void SetTheatreType(string type)
    {
        TheatreType = "regular";
        if (type.ToLower().Trim() == "imax")
        {
            TheatreType = "IMAX";
        }
        else if (type.ToLower().Trim() == "dbox" || type.ToLower().Trim() == "d-box")
        {
            TheatreType = "DBOX";
        }
    }

    public void AddMovie(Movie movie)
    {
        Movies.Add(movie);
    }

    public void RemoveMovie(Movie movie)
    {
        Movies.Remove(movie);
    }

    public override string ToString()
    {
        return $"- Theatre #{ID} (theatre type: {TheatreType}, has recliners: {HasRecliners})";
    }
}