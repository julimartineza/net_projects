namespace UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;

public class IsActive
{
    public bool Value { get; set; }

    public IsActive(bool value)
    {
        Value = value;
    }

    public static readonly IsActive Active = new(true);
    public static readonly IsActive Inactive = new(false);

    public static IsActive Create(bool value)
    {
        return new IsActive(value);
    }

    public void ChangeStatus()
    {
        Value = !Value;
    }

    public bool GetValue() => Value;
}
