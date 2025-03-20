namespace UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;

/// <summary>
/// Represents a learning space type in the system.
/// </summary>
public partial class TypeLS
{
    public string Value { get; }

    private TypeLS(string value)
    {
        Value = value;
    }

    public static readonly TypeLS invalid = new(string.Empty);

    public const int MaxLength = 100;

    /// <summary>
    /// Tries to create a new learning space type object.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="typeLS"></param>
    /// <returns><c>true</c> if the creation was successful; otherwise, <c>false</c></returns>
    public static bool TryCreate(string? value, out TypeLS typeLS)
    {
        typeLS = invalid;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.Length > MaxLength)
        {
            return false;
        }

        typeLS = new TypeLS(value);
        return true;
    }

    /// <summary>
    /// Creates a new learning space type object.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>TypeLS object</returns>
    public static TypeLS Create(string? value)
    {
        if (!TryCreate(value, out var typeLS))
        {
            var exc = new ArgumentException("Invalid Learning Space Type");
            exc.HResult = 3;
            throw exc;
        }
        return typeLS;
    }
}