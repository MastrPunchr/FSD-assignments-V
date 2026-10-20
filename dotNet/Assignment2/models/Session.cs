public class Session{
    public string Title { get; set; }
    public string SpeakerName { get; set; }
    public string SpeakerEmail { get; set; }
    public DateTime StartTime { get; set; }
    public NotificationHandler NotifySpeaker;
    public event SessionChangeHandler SessionChanged;

    public Session(string title, string speaker, string speakerEmail, DateTime startTime,
        NotificationHandler notifySpeaker)
    {
        Title = title;
        SpeakerName = speaker;
        SpeakerEmail = speakerEmail;
        StartTime = startTime;
        NotifySpeaker = notifySpeaker;
        SessionChanged += Logger.Log;
    }

    public void AddAttendee(string name, SessionChangeHandler notify)
    {
        SessionChanged += notify;
        NotifySpeaker?.Invoke($"An attendee named {name} has been added to your session '{Title}'.");
    }

    public void ChangeStartTime(DateTime newTime)
    {
        StartTime = newTime;
        OnSessionChanged($"The start time for '{Title}' has been changed to {newTime}.");
        
    }

    protected virtual void OnSessionChanged(string message)
    {
        SessionChanged?.Invoke(message);
    }
}
