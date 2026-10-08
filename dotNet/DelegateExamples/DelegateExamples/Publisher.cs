namespace DelegateExamples;

public delegate void Subscription(string str);
public class Publisher
{ 
    Subscription? Notify;

    public void Publish(string str)
    {
        if (Notify != null)
        {
            Notify(str);
        }
    }

    public void Subscribe(Subscription newSubscriber)
    {
        if (Notify == null)
        {
            Notify = newSubscriber;
            return;
        }
        Notify += newSubscriber;
    }
}