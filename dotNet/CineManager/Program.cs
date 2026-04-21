namespace CineManager;
public class Program
{
    public static void Main()
    {
        UserInterface();
    }

    public static void UserInterface()
    {
        string userInput = null;
        Console.WriteLine("Welcome to the Movie Theater Management System!\n-----------------------------------------------\n\n");
        while(userInput != "0")
        {
            Console.WriteLine("Main Menu:\n1. Manage Movies\n2. Venues\n0. Exit\n");
            Console.Write("Please enter your choice: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    MovieInterface();
                    break;
                case "2":
                    VenueInterface();
                    break;
                case "0":
                    Console.WriteLine("Thank you for using CineManager!");
                    break;
                default:
                    
                    break;
            }
        }
    }
    
    //--------//
    //        //
    // Venues //
    //        //
    //--------//
    private static void VenueInterface()
    {
        string userInput = null;
        while(userInput != "0")
        {
            Console.WriteLine("\nVenues menu:");
            Console.WriteLine("1. Add a new venue\n2. Manage a venue\n0. Main menu");
            Console.Write("Please enter your choice: ");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddVenue();
                    break;
                case "2":
                    ManageVenue();
                    break;
                case "0":
                    return;
                default:
                    break;
            }
        }   
    }

    private static void AddVenue()
    {
        string userInput = null;
        while (string.IsNullOrEmpty(userInput))
        {
            Console.Write("\nVenue name: ");
            userInput = Console.ReadLine().Trim();
            
            if(string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Invalid input");
            }        
        }
        Venue.Venues.Add(new Venue(userInput));
        Console.WriteLine($"{userInput} venue created.\n");
    }

    private static bool RemoveVenue(Venue venue)
    {
        Console.Write($"Are you sure you want to delete venue {venue.Name}? (y/n): ");
        string input = Console.ReadLine().ToLower();
        if (input == "y")
        {
            Venue.Venues.Remove(venue);
            Console.WriteLine($"\nVenue deleted, returning to menu...");
            return true;
        }
        else
        {
            Console.WriteLine("\nCancelling...");
            return false;
        }
    }
    
    private static void ManageVenue()
    {
        if(Venue.Venues.Count > 0)
        {
            Console.WriteLine("\nWhich venue do you want to manage?");
            foreach (Venue venue in Venue.Venues)
            {
                Console.WriteLine(venue);
            }
        }
        else
        {
            Console.WriteLine("\nException: no venues created, try creating one first");
            return;
        }
        
        Console.Write("\nPlease enter ID number: ");
        string userInput = Console.ReadLine();
        
        //Using LINQ expressions because we can now so I'll do a bit of explaining (checked the C# docs after rider mentioned I could use LINQ for simplicity and performance)
        //this LINQ expression replaces a foreach loop that would iterate through each venue in the list Venues and comparing each one's ID number with userInput, and since we use the firstordefault method it will by default return null if it is not found which is then handled by the following if statement
        Venue currentVenue = Venue.Venues.FirstOrDefault(venue => Convert.ToInt16(userInput) == venue.ID);
        if (currentVenue == null)
        {
            Console.WriteLine("Yeah okay there bud, returning to menu...");
            return;
        }

        while(userInput != "0")
        {
            Console.WriteLine($"\nManaging {currentVenue.Name}\n-----------------------------------------------");
            Console.WriteLine("1. Add a theatre\n2. Manage theatres\n3. Get showtimes\n4. Update venue details\n5. Delete venue\n0. Go back");
            Console.Write("\nPlease enter your choice: ");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddTheatre(currentVenue);
                    break;
                case "2":
                    ManageTheatres(currentVenue);
                    break;
                case "3":
                    //This is option 4 from the guide, I opted to have it in venue management as it allowed users to not need to enter the venue ID and instead just call this function
                    currentVenue.GetShowtimes();
                    break;
                case "4":
                    currentVenue.UpdateVenue();
                    break;
                case "5":
                    bool removed = RemoveVenue(currentVenue);
                    if (removed)
                    {
                        return;
                    }
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("\nInvalid input\n");
                    continue;
            }
        }
    }
    
    //----------//
    //          //
    // Theatres //
    //          //
    //----------//
    private static void AddTheatre(Venue venue)
    {
        Console.Write("\nEnter the type of the new theatre (regular, IMAX, D-Box): ");
        string type = Console.ReadLine();
        Console.Write("Enter whether it has recliners or not (y/n): ");
        string recliners = Console.ReadLine().ToLower();
        bool reclining = false;
        if (recliners == "y")
        {
            reclining = true;
        }
        venue.AddTheatre(reclining, type);
        Console.WriteLine($"A new theatre was added to venue {venue.ID}");
    }
    
    private static bool RemoveTheatre(Venue venue, Theatre th)
    {
        Console.Write($"Are you sure you want to delete theatre {th.ID}? (y/n): ");
        string userInput = Console.ReadLine().ToLower();
        if (userInput == "y")
        {
            venue.RemoveTheatre(th);
            return true;
        }
        else
        {
            Console.WriteLine("Cancelling...\n");
            return false;
        }
    }

    private static void ManageTheatres(Venue venue)
    {
        string userInput = null;
        if(venue.Theatres.Count > 0)
        {
            while (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine($"Theatres in {venue.Name} venue:");
                venue.ListTheatres();
                Console.Write("\nPlease enter theatre ID: ");
                userInput = Console.ReadLine();
            }
        }
        else
        {
            Console.WriteLine("Exception: No theatres created, try creating one first");
            return;
        }

        if (string.IsNullOrEmpty(userInput))
        {
            return;
        }
        
        Theatre currentTheatre = venue.Theatres.FirstOrDefault(th => Convert.ToInt16(userInput) == th.ID);
        if (currentTheatre == null)
        {
            Console.WriteLine("Yeah okay there bud, returning to menu...");
            return;
        }
        
        while(userInput != "0")
        {
            Console.WriteLine($"\nManaging {currentTheatre}\n-----------------------------------------------\n1. Add a movie to theatre\n2. Remove a movie from theatre\n3. Update theatre details\n4. Delete theatre\n0. Go back");
            Console.Write("Please enter your choice: ");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddMovieToTheatre(currentTheatre);
                    break;
                case "2":
                    RemoveMovieFromTheatre(currentTheatre);
                    break;
                case "3":
                    venue.UpdateTheatre(currentTheatre);
                    continue;
                case "4":
                    bool removed = RemoveTheatre(venue, currentTheatre);
                    if (removed)
                    {
                        return;
                    }
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("\nInvalid input\n");
                    continue;
            }
        }
    }

    private static void AddMovieToTheatre(Theatre th)
    {
        Console.WriteLine("What movie would you like to add to this theatre?: ");
        foreach (Movie movie in Movie.Movies)
        {
            Console.WriteLine(movie);
        }
        Console.Write("Please enter movie ID: ");
        try
        {
            int userInput = Convert.ToInt32(Console.ReadLine());
            Movie current = Movie.Movies.FirstOrDefault(mov => mov.ID == userInput);
            th.AddMovie(current);
            Console.WriteLine($"Movie {current.ID} added to theatre {th.ID}");
        }
        catch
        {
            Console.WriteLine("Movie not found");
        }
    }

    private static void RemoveMovieFromTheatre(Theatre th)
    {
        Console.WriteLine("Which movie do you want to remove?:");
        foreach (Movie movie in Movie.Movies)
        {
            Console.WriteLine(movie);
        }
        Console.Write("Please enter movie ID: ");
        try
        {
            int userInput = Convert.ToInt32(Console.ReadLine());
            Movie current = Movie.Movies.FirstOrDefault(mov => mov.ID == userInput);
            Console.WriteLine($"Are you sure you want to remove movie {current.ID} from theatre {th.ID}? (y/n): ");
            string confirm = Console.ReadLine();
            if (confirm.ToLower() == "y")
            {
                th.RemoveMovie(current);
                Console.WriteLine("Movie deleted");
            }
            else
            {
                Console.WriteLine("Cancelling...");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input\n");
        }
    }
    
    //Movies
    //
    //add to theatre
    //remove from theatre

    private static void MovieInterface()
    {
        string userInput = null;
        while(userInput != "0")
        {
            Console.WriteLine(
                $"Movies menu\n-----------------------------------------------\n1. Add a new movie\n2. Remove a movie\n3. Update a movie's details\n0. Main menu\n");
            Console.Write("Please enter your choice: ");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Movie.Add();
                    break;
                case "2":
                    RemoveMovie();
                    break;
                case "3":
                    UpdateMovie();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("\nInvalid input\n");
                    continue;
            }
        }
    }

    private static void RemoveMovie()
    {
        Console.WriteLine("Which movie would you like to remove?: ");
        foreach (Movie movie in Movie.Movies)
        {
            Console.WriteLine(movie);
        }
        Console.Write("Please enter the ID of your selection: ");
        int inputID = Convert.ToInt32(Console.ReadLine());
        Movie current = Movie.Movies.FirstOrDefault(mov => mov.ID == inputID);
        if (current != null)
        {
            current.Remove(current);
        }
        else
        {
            Console.WriteLine("Movie not found\n");
        }
    }

    private static void UpdateMovie()
    {
        Console.WriteLine("Which movie would you like to update?: ");
        foreach (Movie movie in Movie.Movies)
        {
            Console.WriteLine(movie);
        }
        Console.Write("Please enter the ID of your selection: ");
        int inputID = Convert.ToInt32(Console.ReadLine());
        Movie current = Movie.Movies.FirstOrDefault(mov => mov.ID == inputID);
        if (current != null)
        {
            current.Update(current);
        }
        else
        {
            Console.WriteLine("Movie not found\n");
        }
    }
}