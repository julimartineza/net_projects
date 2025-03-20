using UCR.ECCI.PI.Backend.Domain.Users.Entities;
using UCR.ECCI.PI.Backend.Domain.Users.Repositories;
using UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;
using UCR.ECCI.PI.Backend.Application.UserServices;
using Microsoft.VisualBasic;

namespace UCR.ECCI.PI.Backend.Application.UserServices.Implementations;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<GetUserResult> GetUserAsync(string id)
    {
        Guid varTemp = new Guid(id);
        var user = await _userRepository.GetUserAsync(varTemp);
        if (user == null) throw new KeyNotFoundException("User not found.");

        return new GetUserResult(user.UserId.Value, user.Username.Value, user.Avatar.Value, user.IsActive.Value, user.Email.Value);
    }

    public async Task<IEnumerable<ListUsersResult>> ListUsersAsync()
    {
        var users = await _userRepository.ListUsersAsync();
        var result = new List<ListUsersResult>();

        foreach (var user in users)
        {
            result.Add(new ListUsersResult(user.UserId.Value, user.Username.Value, user.Avatar.Value, user.IsActive.Value, user.Email.Value/**, user.IsPerson.Value*/));
        }

        return result;
    }

    public async Task<int> SetUserAsync(SetUserParams newUser)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(newUser.Username))
        {
            throw new ArgumentException("Username error: Invalid Username");
        }

        T? CreateWithErrors<T>(Func<T> createFunc, string propertyName)
        {
            try
            {
                return createFunc();
            }
            catch (Exception ex)
            {
                errors.Add($"{propertyName} error: {ex.Message}");
                return default;
            }
        }

        var user = new User(
            CreateWithErrors(() => PersonId.Create(newUser.Id), nameof(newUser.Id)),
            CreateWithErrors(() => Username.Create(newUser.Username), nameof(newUser.Username)),
            CreateWithErrors(() => Avatar.Create(newUser.Avatar), nameof(newUser.Avatar)),
            CreateWithErrors(() => IsActive.Create(newUser.IsActive), nameof(newUser.IsActive)),
            CreateWithErrors(() => Email.Create(newUser.Email), nameof(newUser.Email))
        );

        //if (errors.Count > 0)
        //{
        //    throw new AggregateException("Errors encountered while creating user properties.",
        //        errors.Select(err => new Exception(err)).ToArray());
        //}

        return await _userRepository.SetUserAsync(user);
    }

    public async Task<int> ChangeUserStatusAsync(ChangeIsActiveParams changeIsActiveParams)
    {
        // Convert Guid to string for Id
        var user = await _userRepository.GetUserAsync(changeIsActiveParams.Id);
        if (user == null) throw new KeyNotFoundException("User not found :(.");

        return await _userRepository.ChangeUserStatusAsync(user);
    }

}
