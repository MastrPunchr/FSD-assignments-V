namespace CineManager;

public class Venue
{
    //Venues don't have IDs because they didn't need them with how the new menus are structured
    public static List<Venue> Venues = new List<Venue>();
    public List<Theatre> Theatres { get; private set; }
    public string Name { get; private set; }
    public int ID { get; }
    
    
    public Venue(string name)
    {
        Name = name;
        Theatres = new List<Theatre>();
        Random rand = new Random();
        int id = rand.Next(1000);
        //checks if the ID is already assigned in venues so that you don't need a tandem list
        while (Venues.Any(venue => venue.ID == id) || id == 0)
        {
            id = rand.Next();
        }
        ID = id;
    }

    public void UpdateVenue()
    {
        Console.Write($"Editing {Name}, enter new name:");
        string userInput = Console.ReadLine();
        if(userInput != null)
        {
            Name = userInput;
        }
    }

    public void GetShowtimes()
    {
        FileWriter writer = new FileWriter($"../../../{Name}_VENUE_Movies.txt");
        int i = 0;
        List<string> venueMovies = new List<string>();
        foreach (Theatre th in Theatres)
        {
            venueMovies.Add($"{i}. Theatre #{th.ID} ({th.TheatreType}, Has recliners: {th.HasRecliners}):\nID   Title               Genre         Release Year   Duration (mins)");
            foreach (Movie movie in th.Movies)
            {
                venueMovies.Add($"{movie.ID}   {movie.Name}           {movie.Genre}     {movie.ReleaseYear}   {movie.Runtime}");
            }
            i++;
        }
        writer.WriteContent(venueMovies);
    }

    public override string ToString()
    {
        return $"- {Name} (ID: {ID})";
    }

    //
    //Theatres
    //
    public void AddTheatre(bool recliners, string theatreType)
    {
        Random rand = new Random();
        int id = rand.Next(26);
        while (Theatres.Any(th => th.ID == id) || id == 0)
        {
            id = rand.Next(26);
        }
        Theatres.Add(new Theatre(id, recliners, theatreType));
    }

    public void RemoveTheatre(Theatre th)
    {
        Theatres.Remove(th);
    }

    public void ListTheatres()
    {
        foreach (Theatre th in Theatres)
        {
            Console.WriteLine(th);
        }
    }

    public void UpdateTheatre(Theatre th)
    {
        Console.Write($"Editing theatre #{th.ID}, enter new theatre type (regular, IMAX, D-Box): ");
        string userInput = Console.ReadLine();
        if(userInput != null)
        {
            th.SetTheatreType(userInput);
        }
        Console.Write("Has recliners? (y/n): ");
        userInput = Console.ReadLine().ToLower();
        if (userInput == "y")
        {
            th.HasRecliners = true;
        } else if (userInput == "n")
        {
            th.HasRecliners = false;
        }
        Console.WriteLine($"Theatre #{th.ID} updated successfully\n");
    }
}