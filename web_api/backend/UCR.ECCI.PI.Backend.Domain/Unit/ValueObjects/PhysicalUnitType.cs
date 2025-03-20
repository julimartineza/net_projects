namespace UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;

/// <summary>
/// Represents the type of a physical unit.
/// </summary>
public class PhysicalUnitType
{

    public string Value { get; set; }

    public static readonly PhysicalUnitType invalid = new(string.Empty);

    public static readonly char[] illegalCharacters = { '@', '#', '$', '%', '^', '&', '*', '(', ')', '!', '~', '`', '{', '}', '[', ']', ':', ';', '"', '<', '>', ',', '.', '/' };

    public const int MaxLength = 17;

    public PhysicalUnitType(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Try to create a new physical unit type object.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="physicalUnitType"></param>
    /// <returns><c>true</c> if the creation was successful; otherwise, <c>false</c></returns>
    public static bool TryCreate(string? value, out PhysicalUnitType physicalUnitType)
    {
        // Run validation
        physicalUnitType = invalid;
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

        physicalUnitType = new PhysicalUnitType(value);
        return true;
    }

    /// <summary>
    /// Creates a new physical unit type object.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>PhysicalUnitType object</returns>
    public static PhysicalUnitType Create(string value)
    {
        if (!TryCreate(value, out var buildingType))
        {
            var exc = new ArgumentException("Invalid Id");
            exc.HResult = 1;
            throw exc;
        }
        return buildingType;
    }
}