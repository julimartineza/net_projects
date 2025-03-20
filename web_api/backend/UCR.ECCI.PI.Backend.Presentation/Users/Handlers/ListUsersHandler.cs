using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.BuildingServices;
using UCR.ECCI.PI.Backend.Application.UserServices;
using UCR.ECCI.PI.Backend.Presentation.Buildings.Mappers;
using UCR.ECCI.PI.Backend.Presentation.Buildings.Responses;
using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;
using UCR.ECCI.PI.Backend.Presentation.Users.Mappers;
using UCR.ECCI.PI.Backend.Presentation.Users.Responses;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Handlers;

internal static class ListUsersHandler
{
    public static async Task<ListUsersResponse> HandleAsync(
        [FromServices] IUserService userService)
    {
        var usersResult = await userService.ListUsersAsync();

        return new ListUsersResponse
        {
            Users = usersResult.Select(user => new UserDto
            {
                UserId = user.Id,
                Username = user.Username,
                Avatar = user.Avatar,
                IsActive = user.IsActive,
                Email = user.Email,
                IsPerson = true 
            }).ToList()
        };
    }
}
