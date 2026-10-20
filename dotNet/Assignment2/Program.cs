using System;
using System.Collections.Generic;

class Program{
    class Email: IEmailService{
        public void SendEmail(string recipient, string subject, string body){
            Console.WriteLine($@"
            [Email]
            To: {recipient}
            Subject: {subject}
            -----------------
            Hello.
            
            {body}
            
            Sincerely,
            Conference Manager.
            ");
        }
    }
    
    static void Main(string[] args){
        HelperFunctions.Email = new Email();

        Console.WriteLine("Welcome to the Conference Management System");

        // Create a conference and set the manager's notification
        Conference conference = HelperFunctions.CreateConference("Tech Innovations 2024", "info@techinnovations2024.com"); 

        while (true){
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1 - Add a Session");
            Console.WriteLine("2 - Add an Attendee to a Session");
            Console.WriteLine("3 - Change Session Start Time");
            Console.WriteLine("4 - Exit");

            Console.Write("Select an option: ");
            string option = Console.ReadLine() ?? "";

            switch (option){
                case "1":
                    AddSession(conference);
                    break;
                case "2":
                    AddAttendeeToSession(conference);
                    break;
                case "3":
                    ChangeSessionTime(conference);
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    static void AddSession(Conference conference){
        Console.Write("Enter session title: ");
        string title = Console.ReadLine() ?? "";
        Console.Write("Enter speaker name: ");
        string speaker = Console.ReadLine() ?? "";
        Console.Write("Enter speaker email: ");
        string speakerEmail = Console.ReadLine() ?? "";
        DateTime startTime;

        while (true){
            Console.Write("Enter start time (yyyy-mm-dd hh:mm): ");
            if (DateTime.TryParse(Console.ReadLine() ?? "", out startTime)){
                break;
            }
            Console.WriteLine("Invalid date format. Please try again.");
        }

        HelperFunctions.CreateSession(conference, title, speaker, speakerEmail, startTime);
    }

    static void AddAttendeeToSession(Conference conference){
        Session? session = SelectSession(conference);
        if (session == null) return;

        Console.Write("Enter attendee name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Enter attendee email: ");
        string email = Console.ReadLine() ?? "";

        HelperFunctions.AddAttendeeToSession(session, name, email);
    }

    static void ChangeSessionTime(Conference conference){
        Session? session = SelectSession(conference);
        if (session == null) return;

        DateTime newStartTime;
        while (true){
            Console.Write("Enter new start time (yyyy-mm-dd hh:mm): ");
            if (DateTime.TryParse(Console.ReadLine() ?? "", out newStartTime)){
                break;
            }
            Console.WriteLine("Invalid date format. Please try again.");
        }
        session.ChangeStartTime(newStartTime);
    }

    static Session? SelectSession(Conference conference){
        if (conference.Sessions.Count == 0){
            Console.WriteLine("No sessions available.");
            return null;
        }

        Console.WriteLine("Available Sessions:");
        for (int i = 0; i < conference.Sessions.Count; i++){
            Console.WriteLine($"{i + 1} - {conference.Sessions[i].Title}");
        }

        int index;
        while (true){
            Console.Write("Select a session by number: ");
            if (int.TryParse(Console.ReadLine() ?? "", out index) && index > 0 && index <= conference.Sessions.Count){
                return conference.Sessions[index - 1];
            }
            Console.WriteLine("Invalid selection. Please try again.");
        }
    }
}
