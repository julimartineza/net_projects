using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.UserServices;
using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Handlers;

public static class ChangeUserStatusHandler
{
    internal static async Task<IResult> HandleAsync(
         [FromServices] IUserService userService,
         [FromQuery] Guid id)  // Using UserDto instead of ChangeIsActiveParams
    {

        var changeStatusParams = new ChangeIsActiveParams(id);

        var result = await userService.ChangeUserStatusAsync(changeStatusParams);

        return result > 0
            ? Results.Ok(new
            {
                Message = "User status updated successfully",
            })
            : Results.NotFound(new { Message = "User not found" });
    }
}
