namespace UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

/// <summary>
/// Represents a type of building.
/// </summary>
public partial class TypeBuilding
{

    public string Value { get; }


    private TypeBuilding(string value)
    {
        Value = value;
    }


    public static readonly TypeBuilding invalid = new(string.Empty);


    public static readonly char[] illegalCharacters = { '@', '#', '$', '%', '^', '&', '*', '(', ')', '!', '~', '`', '{', '}', '[', ']', ':', ';', '"', '<', '>', ',', '.', '/' };


    public const int MaxLength = 17;

    /// <summary>
    /// Validates to create a new instance of the <see cref="TypeBuilding"/> class.
    /// </summary>
    /// <param name="value">The value to be validated the type building.</param>
    /// <param name="typeBuilding">When this method returns, contains the created <see cref="TypeBuilding"/> object if the creation was successful, or <see cref="invalid"/> if the creation failed.</param>
    /// <returns><c>true</c> if the creation was successful; otherwise, <c>false</c>.</returns>
    public static bool TryCreate(string? value, out TypeBuilding typeBuilding)
    {
        // Run validation
        typeBuilding = invalid;
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

        typeBuilding = new TypeBuilding(value);
        return true;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="TypeBuilding"/> class.
    /// </summary>
    /// <param name="value">The value of the type building.</param>
    /// <returns>The created <see cref="TypeBuilding"/> object.</returns>
    /// <exception cref="ArgumentException">Thrown when the creation of the type building fails.</exception>
    public static TypeBuilding Create(string? value)
    {
        if (!TryCreate(value, out var typeBuilding))
        {
            var exc = new ArgumentException("Invalid Building Type");
            exc.HResult = 8;
            throw exc;
        }
        return typeBuilding;
    }
}
