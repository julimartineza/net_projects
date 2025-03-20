using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.UserServices;
using UCR.ECCI.PI.Backend.Presentation.Users.Mappers;
using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;
using UCR.ECCI.PI.Backend.Presentation.Users.Responses;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Handlers
{
    public static class GetUserHandler
    {
        public static async Task<IResult> HandleAsync(
            [FromServices] IUserService userService,
            [FromQuery] Guid id)
        {
            if (id == Guid.Empty)
            {
                return Results.BadRequest(new { Message = "User Id is required", ErrorCode = 400 });
            }

            var entity = await userService.GetUserAsync(id.ToString());
            if (entity == null)
            {
                return Results.NotFound(new { Message = "User not found", ErrorCode = 404 });
            }

            var response = new GetUserResponse
            {
                User = new UserDto
                {
                    UserId = entity.Id,
                    Username = entity.Username,
                    Avatar = entity.Avatar,
                    IsActive = entity.IsActive,
                    Email = entity.Email,
                    IsPerson = true
                }
            };

            return Results.Ok(response);
        }
    }
}
