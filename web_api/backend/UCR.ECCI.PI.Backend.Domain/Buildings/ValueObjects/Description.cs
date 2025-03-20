namespace UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

/// <summary>
/// Represents a description value object.
/// </summary>
public partial class Description
{
   
    public string Value { get; }

    private Description(string value)
    {
        Value = value;
    }
  
    public static readonly Description Invalid = new(string.Empty);
    public const int MaxLength = 100;

    /// <summary>
    /// Validates to create a new description.
    /// </summary>
    /// <param name="value">The value to be validated the type building.</param>
    /// <param name="description">The created description.</param>
    /// <returns>True if the description was created successfully, otherwise false.</returns>
    public static bool TryCreate(string? value, out Description description)
    {
        // Run validation
        description = Invalid;
        if (string.IsNullOrWhiteSpace(value) || value.Length > MaxLength)
        {
            return false;
        }

        description = new Description(value);
        return true;
    }

    /// <summary>
    /// Creates a new description.
    /// </summary>
    /// <param name="value">The value of the description.</param>
    /// <returns>The created description.</returns>
    /// <exception cref="ArgumentException">Thrown when the description is invalid.</exception>
    public static Description Create(string? value)
    {
        if (!TryCreate(value, out var description))
        {
            throw new ArgumentException("Invalid Description") { HResult = 3 };
        }
        return description;
    }
}
