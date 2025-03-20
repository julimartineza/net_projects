using System.Text.RegularExpressions;

namespace UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;

public class Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
        {
            throw new ArgumentException("Invalid Email. The email must have the structure local-part@domain, where the local-part can contain letters (a-z), dots (.), hyphens (-), and underscores (_), and the domain may have subdomains.");
        }
        Value = value;

    }

    public static readonly Email Invalid = new(string.Empty);

    private static readonly Regex EmailRegex = new Regex(
        @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        RegexOptions.Compiled);

    public static bool TryCreate(string? value, out Email email)
    {
        email = Invalid;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (!EmailRegex.IsMatch(value))
        {
            return false;
        }

        email = new Email(value);
        return true;
    }

    public static Email Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
        {
            throw new ArgumentException("Invalid Email. The email must have the structure local-part@domain, where the local-part can contain letters (a-z), dots (.), hyphens (-), and underscores (_), and the domain may have subdomains.");
        }
        return new Email(value);
    }

    public string GetValue() => Value;
}
