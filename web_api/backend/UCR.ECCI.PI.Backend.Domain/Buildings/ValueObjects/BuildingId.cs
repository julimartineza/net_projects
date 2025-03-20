namespace UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

/// <summary>
/// Represents the unique identifier for a building.
/// </summary>
public partial class BuildingId
{

    public string Value { get; }

    private BuildingId(string value)
    {
        Value = value;
    }


    public static readonly BuildingId invalid = new(string.Empty);

    public static readonly char[] illegalCharacters = { '@', '#', '$', '%', '^', '&', '*', '(', ')', '!', '~', '`', '{', '}', '[', ']', ':', ';', '"', '<', '>', ',', '.', '/' };


    public const int MaxLength = 17;

    /// <summary>
    /// Tries to create a new building identifier validating the @value param.
    /// </summary>
    /// <param name="value">The value of the building identifier.</param>
    /// <param name="id">The created building identifier if successful, otherwise an invalid building identifier.</param>
    /// <returns>True if the building identifier was successfully created, otherwise false.</returns>
    public static bool TryCreate(string? value, out BuildingId id)
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

        id = new BuildingId(value);
        return true;
    }

    /// <summary>
    /// Creates a new building identifier if is valid.
    /// </summary>
    /// <param name="value">The value of the building identifier.</param>
    /// <returns>The created building identifier.</returns>
    public static BuildingId Create(string value)
    {
        if (!TryCreate(value, out var id))
        {
            throw new ArgumentException("Invalid Id");
        }
        return id;
    }
}
