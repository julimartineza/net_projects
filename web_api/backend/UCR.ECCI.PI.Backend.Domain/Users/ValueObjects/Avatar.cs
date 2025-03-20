namespace UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;

public class Avatar
{
    public string Value { get; }

    public Avatar(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Avatar image path cannot be empty or null.");
        }
        Value = value;
    }

    public static Avatar Create(string imagePath)
    {
        return new Avatar(imagePath);
    }

    public string GetValue() => Value;
}

