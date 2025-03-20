namespace UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;

/// <summary>
/// Represents the type of an administrative unit.
/// </summary>
public class AdministrativeUnitType
{

    public string Value { get; set; }

    public static readonly AdministrativeUnitType invalid = new(string.Empty);

    public static readonly char[] illegalCharacters = { '@', '#', '$', '%', '^', '&', '*', '(', ')', '!', '~', '`', '{', '}', '[', ']', ':', ';', '"', '<', '>', ',', '.', '/' };

    public const int MaxLength = 100;

    public AdministrativeUnitType(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Try to create a new administrative unit type object.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="administrativeUnitType"></param>
    /// <returns>True if valid, false if not</returns>
    public static bool TryCreate(string? value, out AdministrativeUnitType administrativeUnitType)
    {
        // Run validation
        administrativeUnitType = invalid;
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

        administrativeUnitType = new AdministrativeUnitType(value);
        return true;
    }

    /// <summary>
    /// Creates a new administrative unit type object.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>AdministrativeUnitType object</returns>
    public static AdministrativeUnitType Create(string value)
    {
        if (!TryCreate(value, out var buildingAdministrativeUnitType))
        {
            var exc = new ArgumentException("Invalid Administrative Unit Type");
            exc.HResult = 1;
            throw exc;
        }
        return buildingAdministrativeUnitType;
    }
}