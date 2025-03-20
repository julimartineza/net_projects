using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.UserServices;
using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;
using UCR.ECCI.PI.Backend.Presentation.Users.Mappers;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Handlers;

public static class SetUserHandler
{
    internal static async Task<IResult> HandleAsync(
            [FromServices] IUserService userService,
            [FromServices] IPersonService personService,
            [FromBody] UserDto newUser) 
    {
        if (newUser == null)
        {
            return Results.BadRequest(new { Message = "User data is required", ErrorCode = 400 });
        }

        var user = newUser.ToEntity();

        var setUserParams = new SetUserParams
        (
            newUser.UserId,      
            newUser.Username,       
            newUser.Avatar,         
            newUser.IsActive,       
            newUser.Email,          
            newUser.IsPerson    
        );

        var result = await userService.SetUserAsync(setUserParams);

        // If the user should be created in the person service
        if (newUser.IsPerson)
        {
            var personParams = new SetPersonParams(newUser.UserId, newUser.Username, newUser.Username, newUser.Username, newUser.Email);
            await personService.SetPersonAsync(personParams);
        }

        return result > 0
            ? Results.Created($"/users/{newUser.UserId}", newUser)
            : Results.BadRequest(new { Message = "Failed to set user", ErrorCode = 400 });
    }
}
