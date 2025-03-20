namespace UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

/// <summary>
/// Represents the dimensions of a building.
/// </summary>
public partial class Dimensions
{
    public decimal Value { get; }


    public Dimensions(decimal value)
    {
        Value = value;
    }

    public static readonly Dimensions Invalid = new(decimal.Zero);

    /// <summary>
    /// Validates  to create a new instance of the <see cref="Dimensions"/> class.
    /// </summary>
    /// <param name="value">The value of the dimensions.</param>
    /// <param name="dimensions">The created dimensions object.</param>
    /// <returns><c>true</c> if the dimensions object was successfully created, otherwise <c>false</c>.</returns>
    public static bool TryCreate(decimal value, out Dimensions dimensions)
    {
        dimensions = Invalid;
        if (value <= 0 || Math.Round(value, 4) != value)
        {
            return false;
        }

        dimensions = new Dimensions(value);
        return true;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="Dimensions"/> class.
    /// </summary>
    /// <param name="value">The value of the dimensions.</param>
    /// <returns>The created dimensions object.</returns>
    public static Dimensions Create(decimal value)
    {
        if (!TryCreate(value, out var dimensions))
        {
            throw new ArgumentException("Invalid Dimensions") { HResult = 6 };
        }
        return dimensions;
    }
}
