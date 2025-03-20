using UCR.ECCI.PI.Backend.Application.UserServices;
using UCR.ECCI.PI.Backend.Domain.Users.Entities;


namespace UCR.ECCI.PI.Backend.Application.UserServices;

public interface IUserService
{
    /// <summary>
    /// Get a specific user by Id.
    /// </summary>
    /// <param name="id">The user's Id.</param>
    public Task<GetUserResult> GetUserAsync(string id);

    /// <summary>
    /// List all users in the system.
    /// </summary>
    public Task<IEnumerable<ListUsersResult>> ListUsersAsync();

    /// <summary>
    /// Set a user in the system.
    /// </summary>
    /// <param name="newUser">The user to set.</param>
    public Task<int> SetUserAsync(SetUserParams newUser);

    /// <summary>
    /// Change the user's active status (active/inactive).
    /// </summary>
    /// <param name="changeIsActiveParams">User's Id and desired active status.</param>
    public Task<int> ChangeUserStatusAsync(ChangeIsActiveParams changeIsActiveParams);

}
