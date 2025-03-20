namespace UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;


/// <summary>
/// Represents a floor in the system.
/// </summary>
public partial class Floor
{
    public int Value { get; }

    public Floor(int value)
    {
        Value = value;
    }

    public static readonly Floor invalid = new(0);

    public const int LimitValue = 100;

    /// <summary>
    /// Try to create a new floor object.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="intObject"></param>
    /// <returns><c>true</c> if the creation was successful; otherwise, <c>false</c></returns>
    public static bool TryCreate(int value, out Floor intObject)
    {
        intObject = invalid;
        if (value >= LimitValue || value <= 0)
        {
            return false;
        }

        intObject = new Floor(value);
        return true;
    }

    /// <summary>
    /// Create a new floor object.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Floor object</returns>
    public static Floor Create(int value)
    {
        if (!TryCreate(value, out var floor))
        {
            var exc = new ArgumentException("Invalid floor number");
            exc.HResult = 5;
            throw exc;
        }
        return floor;
    }
}