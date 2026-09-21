namespace Banking.Core;

public class Customer
{
    private string _email = string.Empty;
    public required string FirstName { get; init; }
    public required string LastName { get; init; }

    public required string Email
    {
        get { return _email; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains('@'))
                throw new ArgumentException("Email bust contain an '@' character.", nameof(value));
            _email = value.Trim();
        }
    }

    public string Fullname => $"{FirstName} {LastName}";
}