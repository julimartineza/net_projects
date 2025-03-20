namespace UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

public partial class Coordinate
{

    public decimal Value { get; }

    public Coordinate(decimal value)
    {
        Value = value;
    }


    public static readonly Coordinate invalid = new(decimal.Zero);


    public const decimal LimitValue = 9999.9999m;

    /// <summary>
    /// Validates value trying to create as Coordinate
    /// to create a new <see cref="Coordinate"/> object with the specified value.
    /// </summary>
    /// <param name="value">The value to be validated the type building.</param>
    /// <param name="coordinate">When this method returns, contains the created <see cref="Coordinate"/> object if the creation was successful, or <see cref="invalid"/> if the creation failed.</param>
    /// <returns><c>true</c> if the creation was successful; otherwise, <c>false</c>.</returns>
    public static bool TryCreate(decimal value, out Coordinate coordinate)
    {
        // Size limit validation
        coordinate = invalid;
        if (value >= LimitValue || value <= -1 * LimitValue)
        {
            return false;
        }

        if (Math.Round(value, 4) != value)
        {
            return false;
        }

        coordinate = new Coordinate(value);
        return true;
    }

    /// <summary>
    /// Creates a new <see cref="Coordinate"/> object with the specified value.
    /// </summary>
    /// <param name="value">The value of the coordinate.</param>
    /// <returns>The created <see cref="Coordinate"/> object.</returns>
    /// <exception cref="ArgumentException">Thrown when the creation of the coordinate fails.</exception>
    public static Coordinate Create(decimal value)
    {
        if (!TryCreate(value, out var coordinate))
        {
            var exc = new ArgumentException("Invalid Coordinates");
            exc.HResult = 5;
            throw exc;
        }
        return coordinate;
    }
}
