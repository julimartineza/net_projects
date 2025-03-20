using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Users.Entities;
using UCR.ECCI.PI.Backend.Domain.Users.Repositories;

namespace UCR.ECCI.PI.Backend.Infrastructure.EntityUser.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class with the provided database context.
    /// </summary>
    /// <param name="databaseContext">The database context used for accessing the database.</param>
    public UserRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    /// <summary>
    /// Retrieves a user by name.
    /// </summary>
    /// <param name="name">The name of the user to search for.</param>
    public Task<User?> GetUserAsync(Guid id)
    {
        return Task.FromResult(_databaseContext.User
        .AsEnumerable()
        .FirstOrDefault(u => u.UserId.GetValue() == id));
    }

    /// <summary>
    /// Lists all users in the database.
    /// </summary>
    public async Task<IEnumerable<User>> ListUsersAsync()
    {
        return await _databaseContext.User.ToListAsync();
    }

    /// <summary>
    /// Adds a new user to the database.
    /// </summary>
    /// <param name="user">The user entity to add.</param>
    public async Task<int> SetUserAsync(User user)
    {
        _databaseContext.User.Add(user);
        return await _databaseContext.SaveChangesAsync();
    }

    /// <summary>
    /// Edits an existing user's information.
    /// </summary>
    /// <param name="user">The updated user entity.</param>
    public async Task<int> EditUserAsync(User user)
    {
        _databaseContext.User.Update(user);
        return await _databaseContext.SaveChangesAsync();
    }

    /// <summary>
    /// Changes the active status of a user.
    /// </summary>
    /// <param name="user">The user whose status is to be changed.</param>
    public async Task<int> ChangeUserStatusAsync(User user)
    {
        user.IsActive.ChangeStatus();
        _databaseContext.User.Update(user);
        await _databaseContext.SaveChangesAsync(); 
        if (user.IsActive.GetValue())
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// Retrieves a user by their username or email.
    /// </summary>
    /// <param name="usernameOrEmail">The username or email to search by.</param>
    public async Task<User?> GetUserByUsernameOrEmailAsync(string usernameOrEmail)
    {
        var user = _databaseContext.User
        .AsEnumerable()
        .FirstOrDefault(u => u.Username.GetValue() == usernameOrEmail);

        if (user == null)
        {
            var person = _databaseContext.Person
                .AsEnumerable()
                .FirstOrDefault(u => u.Username.GetValue() == usernameOrEmail);

            if (person != null)
            {
                user = await _databaseContext.User
                    .FirstOrDefaultAsync(u => u.UserId.GetValue() == person.PersonId.GetValue());
            }
        }
        return user;
    }

}
