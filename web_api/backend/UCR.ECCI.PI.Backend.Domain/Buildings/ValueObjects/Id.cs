namespace UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

/// <summary>
/// Represents an identifier for a building.
/// </summary>
public class Id
{

    public string Value { get; set; }


    public static readonly Id invalid = new(string.Empty);


    public static readonly char[] illegalCharacters = { '@', '#', '$', '%', '^', '&', '*', '(', ')', '!', '~', '`', '{', '}', '[', ']', ':', ';', '"', '<', '>', ',', '.', '/' };

    public const int MaxLength = 17;

   
    public Id(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Validates to create a new <see cref="Id"/> instance from the specified value.
    /// </summary>
    /// <param name="value">The value of the identifier.</param>
    /// <param name="id">When this method returns, contains the created <see cref="Id"/> instance if the creation was successful, or <see cref="invalid"/> if the creation failed.</param>
    /// <returns><c>true</c> if the creation was successful; otherwise, <c>false</c>.</returns>
    public static bool TryCreate(string? value, out Id id)
    {
        // Run validation
        id = invalid;
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

        id = new Id(value);
        return true;
    }

    /// <summary>
    /// Creates a new <see cref="Id"/> instance from the specified value.
    /// </summary>
    /// <param name="value">The value to be validated the type building.</param>
    /// <returns>The created <see cref="Id"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown when the creation of the <see cref="Id"/> instance fails.</exception>
    public static Id Create(string value)
    {
        if (!TryCreate(value, out var id))
        {
            var exc = new ArgumentException("Invalid Id");
            exc.HResult = 1;
            throw exc;
        }
        return id;
    }
}
