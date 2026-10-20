public class Conference{
    public string Name { get; set; }
    public List<Session> Sessions { get; set; }
    public NotificationHandler NotifyManager { get; init; }

    public Conference(string name, NotificationHandler notifyManager)
    {
        Name = name;
        Sessions = new();
        NotifyManager = notifyManager;
    }

    public void AddSession(Session session)
    {
        Sessions.Add(session);
        NotifyManager?.Invoke($"A new session titled '{session.Title}' has been added to the conference '{Name}'.");
    }
}