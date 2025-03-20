namespace UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;

/// <summary>
/// Represents the location of a learning space.
/// </summary>
public class LocatedIn
{

    public string Value { get; set; }

    public static readonly LocatedIn invalid = new(string.Empty);

    public static readonly char[] illegalCharacters = { '@', '#', '$', '%', '^', '&', '*', '(', ')', '!', '~', '`', '{', '}', '[', ']', ':', ';', '"', '<', '>', ',', '.', '/' };

    public const int MaxLength = 17;

    public LocatedIn(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Try to create a new located in object.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="locatedIn"></param>
    /// <returns><c>true</c> if the creation was successful; otherwise, <c>false</c></returns>
    public static bool TryCreate(string? value, out LocatedIn locatedIn)
    {
        // Run validation
        locatedIn = invalid;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.IndexOfAny(illegalCharacters) != -1)
        {
            return false;
        }

        if (value.Length > MaxLength)
        {
            return false;
        }

        locatedIn = new LocatedIn(value);
        return true;
    }

    /// <summary>
    /// Creates a new located in object.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>LocatedIn object</returns>
    public static LocatedIn Create(string value)
    {
        if (!TryCreate(value, out var locatedIn))
        {
            var exc = new ArgumentException("Invalid key");
            exc.HResult = 1;
            throw exc;
        }
        return locatedIn;
    }

}