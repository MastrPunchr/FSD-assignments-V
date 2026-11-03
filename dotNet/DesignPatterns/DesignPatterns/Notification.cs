namespace DesignPatterns;

public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Email: {message}");
}

public class SmsNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"SMS: {message}");
}

public class PushNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Push: {message}");
}

public class NotificationFactory
{
    public INotification Create(string channel)
    {
        return channel switch
        {
            "email" => new EmailNotification(),
            "sms" => new SmsNotification(),
            "push" => new PushNotification(),
            _ => throw new ArgumentException($"Unknown channel: {channel}")
        };
    }
}

class Notification
{
    public static void Run()
    {
        NotificationFactory factory = new NotificationFactory();
        string[] channels = { "email", "sms", "push" };

        foreach (string channel in channels)
        {
            INotification notification = factory.Create(channel);
            notification.Send("Your order has shipped");
        }
    }
}