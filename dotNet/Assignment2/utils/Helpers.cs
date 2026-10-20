public interface IEmailService{
    void SendEmail(string recipient, string subject, string body);
}

public class HelperFunctions {

    public static IEmailService Email;

    // Creates a new conference, returning the instance
    public static Conference CreateConference(string name, string managerEmail)
    {
        return new Conference(name, _ => Email.SendEmail(managerEmail, "Conference Notification", "awawa")); //no example for what the output of this was supposed to look like, plus this is never called
    }

    // Create a new session and add it to the conference
    public static void CreateSession(Conference conference, string title, string speaker, string speakerEmail, DateTime startTime)
    {
        var session = new Session(title, speaker, speakerEmail, startTime, _ => Email.SendEmail(speakerEmail, "Session Notification", $"A new session titled '{title}' has been added to the conference '{conference.Name}'."));
        conference.AddSession(session);
    }

    // Add an attendee to a session
    public static void AddAttendeeToSession(Session session, string name, string email){
        session.AddAttendee(name, _ => Email.SendEmail(email, "Session Notification", $"An attendee named '{name}' has been added to your session '{session.Title}'."));
    }

}