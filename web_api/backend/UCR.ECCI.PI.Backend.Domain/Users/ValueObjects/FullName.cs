namespace UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;

public class FullName
{
    public string Value { get; }

    public FullName(string value)
    {
        Value = value;
    }

    public static readonly FullName Invalid = new(string.Empty);

    public const int MaxLength = 100;
    private static readonly char[] IllegalCharacters = { '@', '#', '$', '%', '^', '&', '*', '(', ')', '!', '~', '`', '{', '}', '[', ']', ':', ';', '"', '<', ',', '.', '/' };

    public static bool TryCreate(string? value, out FullName fullName)
    {
        fullName = Invalid;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.IndexOfAny(IllegalCharacters) != -1)
        {
            return false;
        }

        if (value.Length > MaxLength)
        {
            return false;
        }

        fullName = new FullName(value);
        return true;
    }

    public static FullName Create(string? value)
    {
        if (!TryCreate(value, out var fullName))
        {
            throw new ArgumentException("Invalid FullName");
        }
        return fullName;
    }

    public string GetValue() => Value;
}
