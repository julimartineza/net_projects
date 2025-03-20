namespace UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

/// <summary>
/// Represents the amount of floors in a building.
/// </summary>
public partial class Floors
{
    public int Value { get; }

    public Floors(int value)
    {
        Value = value;
    }

    public static readonly Floors invalid = new Floors(0);

    public const int LimitValue = 100;


    /// <summary>
    /// Try to create a new floor object.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="intObject"></param>
    /// <returns> <c>true</c> if the creation was successful; otherwise, <c>false</c></returns>
    public static bool TryCreate(int value, out Floors intObject)
    {
        // Size limit validation
        intObject = invalid;
        if (value >= LimitValue || value <= 0)
        {
            return false;
        }

        intObject = new Floors(value);
        return true;
    }

    /// <summary>
    /// Create a new floor object.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>floors object</returns>
    public static Floors Create(int value)
    {
        if (!TryCreate(value, out var floors))
        {
            var exc = new ArgumentException("Invalid floor amount");
            exc.HResult = 5;
            throw exc;
        }
        return floors;
    }
}