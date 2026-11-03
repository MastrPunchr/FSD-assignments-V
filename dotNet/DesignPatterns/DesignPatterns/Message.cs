namespace DesignPatterns;

public interface IMessage
{
    string GetText();
}

public class PlainMessage : IMessage
{
    private string _text;

    public PlainMessage(string text)
    {
        _text = text;
    }

    public string GetText() => _text;
}

public abstract class MessageDecorator : IMessage
{
    protected readonly IMessage _inner;

    protected MessageDecorator(IMessage inner)
    {
        _inner = inner;
    }

    public virtual string GetText() => _inner.GetText();
}

public class PrefixDecorator : MessageDecorator
{
    private string _prefix;

    public PrefixDecorator(IMessage inner, string prefix) : base(inner)
    {
        _prefix = prefix;
    }

    public string GetText() => $"{_prefix} " + _inner.GetText();
}

public class SignatureDecorator : MessageDecorator
{
    private string _sig;

    public SignatureDecorator(IMessage inner, string sig) : base(inner)
    {
        _sig = sig;
    }

    public string GetText() => _inner.GetText() + $", {_sig}";
}

public class ShoutDecorator : MessageDecorator
{
    public ShoutDecorator(IMessage inner) : base(inner){ }

    public string GetText() => _inner.GetText().ToUpper();
}

public class Message
{
    public static void Run()
    {
        IMessage message = new PlainMessage("Server restart at 5pm");
        Console.WriteLine(message.GetText());
        message = new PrefixDecorator(message, "[URGENT]");
        Console.WriteLine(message.GetText());
        message = new SignatureDecorator(message, "IT Team");
        Console.WriteLine(message.GetText());
        message = new ShoutDecorator(message);
        Console.WriteLine(message.GetText());
    }
}