namespace UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;

public class PersonId
{
    public Guid Value { get; }

    public PersonId(Guid value)
    {
        Value = value;
    }

    public static readonly PersonId Invalid = new(Guid.Empty);

    public static PersonId Create(Guid value)
    {
        return new PersonId(value);
    }

    public Guid GetValue() => Value;
}

