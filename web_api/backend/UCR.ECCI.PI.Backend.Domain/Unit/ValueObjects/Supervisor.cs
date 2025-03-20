namespace UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;

/// <summary>
/// Represents a supervisor in the system.
/// </summary>
public class Supervisor
{

    public string Value { get; set; }

    public static readonly Supervisor invalid = new(string.Empty);

    public static readonly char[] illegalCharacters = { '@', '#', '$', '%', '^', '&', '*', '(', ')', '!', '~', '`', '{', '}', '[', ']', ':', ';', '"', '<', '>', ',', '.', '/' };

    public const int MaxLength = 100;
    public Supervisor(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Try to create a new supervisor object.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="supervisor"></param>
    /// <returns><c>true</c> if the creation was successful; otherwise, <c>false</c></returns>
    public static bool TryCreate(string? value, out Supervisor supervisor)
    {
        // Run validation
        supervisor = invalid;
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

        supervisor = new Supervisor(value);
        return true;
    }

    /// <summary>
    /// Creates a new supervisor object.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Supervisor object</returns>
    public static Supervisor Create(string value)
    {
        if (!TryCreate(value, out var supervisor))
        {
            var exc = new ArgumentException("Invalid supervisor");
            exc.HResult = 1;
            throw exc;
        }
        return supervisor;
    }

}