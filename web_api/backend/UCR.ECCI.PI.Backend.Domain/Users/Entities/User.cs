using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;

namespace UCR.ECCI.PI.Backend.Domain.Users.Entities;

public class User
{
    public User(PersonId userId, Username username, Avatar avatar, IsActive isActive, Email email)
    {
        UserId = userId;
        Username = username;
        Avatar = avatar;
        IsActive = isActive;
        Email = email;
    }

    public User() { }


    public PersonId UserId { get; }

    public Username Username { get; }

    public Avatar Avatar { get; }

    public IsActive IsActive { get; private set; }

    public IsPerson IsPerson { get; }

    public Email Email { get; }

    public static User Create(Guid userId, string username, string password, string avatar, bool isActive, string email)
    {
        return new User
        (
            PersonId.Create(Guid.NewGuid()),
            new Username(username),
            new Avatar(avatar),
            new IsActive(isActive),
            new Email(email)
        );
    }

    public void ChangeStatus(IsActive newStatus)
    {
        IsActive = newStatus;
    }
}
