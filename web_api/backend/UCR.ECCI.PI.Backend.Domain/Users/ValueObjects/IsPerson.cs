namespace UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;

public class IsPerson
{
    public bool Value { get; set; }

    public IsPerson(bool value)
    {
        Value = value;
    }

    public static readonly IsPerson Active = new(true);
    public static readonly IsPerson Inactive = new(false);

    public static IsPerson Create(bool value)
    {
        return new IsPerson(value);
    }

    public bool GetValue() => Value;
}
