using System.Text.RegularExpressions;

namespace UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;

public class EncryptedPassword
{
    private string Value { get; }

    public EncryptedPassword(string value)
    {
        Value = value;
    }

    public static readonly EncryptedPassword Invalid = new(string.Empty);

    public const int MinLength = 8;
    public const int MaxLength = 64;

    private static readonly Regex PasswordRegex = new Regex(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+={}\[\]:;\""<>,.?/-]).{8,64}$",
        RegexOptions.Compiled);

    public static bool TryCreate(string? value, out EncryptedPassword password)
    {
        password = Invalid;
        if (string.IsNullOrWhiteSpace(value) || value.Length < MinLength || value.Length > MaxLength)
        {
            return false;
        }

        if (!PasswordRegex.IsMatch(value))
        {
            return false;
        }

        password = new EncryptedPassword(value);
        return true;
    }

    public static EncryptedPassword Create(string? value)
    {
        if (!TryCreate(value, out var password))
        {
            throw new ArgumentException("Invalid EncryptedPassword. The password must contain at least one lowercase letter, one uppercase letter, one digit, one special character, and be between 8 and 64 characters long.");
        }
        return password;
    }

    public string GetValue() => Value;
}

