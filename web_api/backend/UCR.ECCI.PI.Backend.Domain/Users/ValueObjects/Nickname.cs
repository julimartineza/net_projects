namespace UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;

public class Nickname
{
    public string Value { get; }

    public Nickname(string value)
    {
        Value = value;
    }

    public static readonly Nickname Invalid = new(string.Empty);

    public const int MaxLength = 30;

    public static bool TryCreate(string? value, out Nickname nickname)
    {
        nickname = Invalid;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.Length > MaxLength)
        {
            return false;
        }

        nickname = new Nickname(value);
        return true;
    }

    public static Nickname Create(string? value)
    {
        if (!TryCreate(value, out var nickname))
        {
            throw new ArgumentException("Invalid Nickname");
        }
        return nickname;
    }

    public string GetValue() => Value;
}
