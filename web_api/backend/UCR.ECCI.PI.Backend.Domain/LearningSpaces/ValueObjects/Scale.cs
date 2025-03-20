namespace UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;

/// <summary>
/// Represents a scale in the system.
/// </summary>
public partial class Scale
{
    public decimal Value { get; }

    private Scale(decimal value)
    {
        Value = value;
    }

    public static readonly Scale invalid = new(decimal.Zero);

    public const decimal LimitValue = 9999.9999m;

    /// <summary>
    /// Try to create a new scale object.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="scale"></param>
    /// <returns><c>true</c> if the creation was successful; otherwise, <c>false</c></returns>
    public static bool TryCreate(decimal value, out Scale scale)
    {
        scale = invalid;
        if (value >= LimitValue || value <= 0)
        {
            return false;
        }

        if (Math.Round(value, 4) != value)
        {
            return false;
        }

        scale = new Scale(value);
        return true;
    }

    /// <summary>
    /// Create a new scale object.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Scale object</returns>
    public static Scale Create(decimal value)
    {
        if (!TryCreate(value, out var scale))
        {
            var exc = new ArgumentException("Invalid Scale");
            exc.HResult = 3;
            throw exc;
        }
        return scale;
    }
}