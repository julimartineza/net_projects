using UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;

namespace UCR.ECCI.PI.Backend.Domain.Users.Entities;

public class Person
{
    public Person(FullName name, Nickname nickname, Username username, Email email, PersonId personId)
    {
        FullName = name;
        Nickname = nickname;
        Username = username;
        Email = email;
        PersonId = personId;
    }

    public Person(FullName name, Nickname nickname, Username username, Email email)
    {
        FullName = name;
        Nickname = nickname;
        Username = username;
        Email = email;
        PersonId = PersonId.Create(Guid.NewGuid());
    }
    public Person() { }
    // Factory method for creating Person from the database
    public static Person Create(string fullName, string nickname, string username, string email)
    {
        return new Person(new FullName(fullName), new Nickname(nickname), new Username(username), new Email(email));
    }

    public FullName FullName { get; }

    public Nickname Nickname { get; }

    public Username Username { get; }
    public Email Email { get; }

    public PersonId PersonId { get; }
}
