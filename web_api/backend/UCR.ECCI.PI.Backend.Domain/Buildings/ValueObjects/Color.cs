namespace UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

/// <summary>
/// Represents a color value object.
/// </summary>
public partial class Color
{
    /// <summary>
    /// Gets the value of the color.
    /// </summary>
    public string Value { get; }


    private Color(string value)
    {
        Value = value;
    }

    public static readonly Color invalid = new(string.Empty);


    public static readonly char[] illegalCharacters = { '@', '#', '$', '%', '^', '&', '*', '(', ')', '!', '~', '`', '{', '}', '[', ']', ':', ';', '"', '<', '>', ',', '.', '/' };


    public const int MaxLength = 17;

    /// <summary>
    /// Tries to create a color value object from the specified string value.
    /// </summary>
    /// <param name="value">The value to be validated the type building.</param>
    /// <param name="coordinate">When this method returns, contains the created
    /// <returns><c>true</c> if the color value object was successfully created; otherwise, <c>false</c>.</returns>
    public static bool TryCreate(string? value, out Color color)
    {
        // Run validation
        color = invalid;
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

        color = new Color(value);
        return true;
    }

    /// <summary>
    /// Creates a color value object from the specified string value.
    /// </summary>
    /// <param name="value">The string value representing the color.</param>
    /// <returns>The color value object.</returns>
    /// <exception cref="ArgumentException">Thrown when the specified string value is invalid.</exception>
    public static Color Create(string? value)
    {
        if (!TryCreate(value, out var color))
        {
            var exc = new ArgumentException("Invalid Color");
            exc.HResult = 4;
            throw exc;
        }
        return color;
    }
}
