namespace CineManager;

public class Movie
{
    public static List<Movie> Movies = new List<Movie>();
    public int ID { get; private set; }
    public string Name { get; private set; }
    public int ReleaseYear { get; private set; }
    public string Genre { get; private set; }
    public int Runtime { get; private set; }
    public Movie(string name, string genre, int releaseYear, int runtime)
    {
        Name = name;
        Genre = genre;
        ReleaseYear = releaseYear;
        Runtime = runtime;

        Random rand = new Random();
        int id = rand.Next(1000);
        while (Movies.Any(movie => movie.ID == id) || id == 0)
        {
            id = rand.Next(1000);
        }
        ID = id;
    }

    public static void Add()
    {
        Console.Write("Enter the title of the movie: ");
        string name = Console.ReadLine();
        Console.Write("Enter the genre of the movie: ");
        string genre = Console.ReadLine();
        Console.Write("Enter the release year of the movie: ");
        int year;
        try
        {
            year = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            year = 0;
        }
        Console.Write("Enter the duration of the movie in minutes: ");
        int length;
        try
        {
            length = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            length = 0;
        }
        Movies.Add(new Movie(name, genre, year, length));
    }

    public void Remove(Movie movie)
    {
        Console.Write($"Are you sure you want to remove {Name}? (y/n): ");
        string userInput = Console.ReadLine().ToLower();
        if (userInput == "y")
        {
            Movies.Remove(movie);
        }
        else
        {
            Console.WriteLine("Cancelling...");
        }
    }

    public void Update(Movie movie)
    {
        Console.WriteLine($"Editing movie {ID} (leave fields blank to leave unchanged)");
        Console.Write("Movie name: ");
        string name = Console.ReadLine();
        if (name != Name && !string.IsNullOrEmpty(name))
        {
            Name = name;
        }
        Console.Write("Movie genre: ");
        string genre = Console.ReadLine();
        if (genre != Genre && !string.IsNullOrEmpty(genre))
        {
            Genre = genre;
        }
        Console.Write("Release year: ");
        string year1 = Console.ReadLine();
        int year;
        if(!string.IsNullOrEmpty(year1))
        {
            try
            {
                year = Convert.ToInt32(year1);
                if (year != 0)
                {
                    ReleaseYear = year;
                }
            }
            catch
            {
                return;
            }
        }
        Console.Write("Movie length: ");
        int length;
        string length1= Console.ReadLine();
        if (!string.IsNullOrEmpty(length1))
        {
            try
            {
                length = Convert.ToInt32(length1);
                if (length != 0) Runtime = length;
            }
            catch
            {
                //suppressing errors
            }
        }
        Console.WriteLine($"Movie {ID} updated");
    }


    public override string ToString()
    {
        return $"- {Name} (ID: {ID}), Genre: {Genre}, Release year: {ReleaseYear}, Runtime: {Runtime} mins";
    }
}