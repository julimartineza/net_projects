namespace UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

/// <summary>
/// Represents the Name for a building.
/// </summary>
public class Name
{
    public string Value { get; }

    private Name(string value)
    {
        Value = value;
    }

    public static readonly Name invalid = new(string.Empty);

    public static readonly char[] illegalCharacters = { '@', '#', '$', '%', '^', '&', '*', '(', ')', '!', '~', '`', '{', '}', '[', ']', ':', ';', '"', '<', ',', '.', '/' };

    public const int MaxLength = 50;


    /// <summary>
    /// Tries to create a new building identifier validating the @value param.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="name"></param>
    /// <returns><c>true</c> if the creation was successful; otherwise, <c>false</c></returns>
    public static bool TryCreate(string? value, out Name name)
    {
        // Run validation
        name = invalid;
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

        name = new Name(value);
        return true;
    }

    /// <summary>
    /// Creates a new building identifier if is valid.
    /// </summary>
    /// <param name="value"></param>
    /// <returns> Name object</returns>
    public static Name Create(string? value)
    {
        if (!TryCreate(value, out var name))
        {
            var exc = new ArgumentException("Invalid Name");
            exc.HResult = 2;
            throw exc;
        }
        return name;
    }
}