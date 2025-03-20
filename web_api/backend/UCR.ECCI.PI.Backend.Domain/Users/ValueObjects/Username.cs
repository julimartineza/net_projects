namespace UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;

public class Username
{
    public string Value { get; }

    public Username(string value)
    {
        Value = value;
    }

    public static readonly Username Invalid = new(string.Empty);

    public const int MaxLength = 50;

    public static bool TryCreate(string? value, out Username username)
    {
        username = Invalid;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.Length > MaxLength)
        {
            return false;
        }

        username = new Username(value);
        return true;
    }

    public static Username Create(string? value)
    {
        if (!TryCreate(value, out var username))
        {
            throw new ArgumentException("Invalid Username");
        }
        return username;
    }

    public string GetValue() => Value;
}
