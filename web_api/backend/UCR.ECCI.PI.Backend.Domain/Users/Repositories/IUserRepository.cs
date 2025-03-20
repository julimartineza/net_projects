using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR.ECCI.PI.Backend.Domain.Users.Entities;
using UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;

namespace UCR.ECCI.PI.Backend.Domain.Users.Repositories;

public interface IUserRepository
{
    /// <summary>
    /// Retrieves an user attributes by its name.Matches similar @param name names in the database.
    /// </summary>
    /// <param name="name">The name of the user to search.</param>
    /// <returns>the user with the specified name.</returns>
    public Task<User?> GetUserAsync(Guid id);

    public Task<IEnumerable<User>> ListUsersAsync();

    /// <summary>
    /// Sets an user.
    /// </summary>
    /// <param Users="user">The user to set.</param>
    public Task<int> SetUserAsync(User user);

    /// <summary>
    /// Edits an user information
    /// </summary>
    /// <param User="users"></param>
    /// <returns>  0 when edited succesfully </returns>
    public Task<int> EditUserAsync(User user);

    /// <summary>
    /// Changes the active status of a user.
    /// </summary>
    /// <param name="user">The user whose status is to be changed.</param>
    /// <returns>An integer representing the result of the operation, where 0 indicates success.</returns>
    public Task<int> ChangeUserStatusAsync(User user);

    /// <summary>
    /// Retrieves a user by their username or email.
    /// </summary>
    /// <param name="usernameOrEmail">The username or email of the user to search for.</param>
    /// <returns>The user with the specified username or email, or null if not found.</returns>
    public Task<User> GetUserByUsernameOrEmailAsync(string usernameOrEmail);

    ///// <summary>
    ///// Validates the login credentials of a user.
    ///// </summary>
    ///// <param name="usernameOrEmail">The username or email of the user trying to log in.</param>
    ///// <param name="encryptedPassword">The encrypted password of the user.</param>
    ///// <returns>The authenticated user, or null if authentication fails.</returns>
    //public Task<User?> ValidateUserCredentialsAsync(string usernameOrEmail, string encryptedPassword);

    ///// <summary>
    ///// Initiates a password reset process by validating and preparing necessary steps.
    ///// </summary>
    ///// <param name="email">The email of the user requesting a password reset.</param>
    ///// <returns>A boolean indicating if the reset process was initiated successfully.</returns>
    //public Task<bool> ForgotPasswordAsync(string email);

}
