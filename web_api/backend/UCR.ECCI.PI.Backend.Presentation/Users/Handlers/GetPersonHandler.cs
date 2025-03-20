using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.UserServices;
using UCR.ECCI.PI.Backend.Presentation.Users.Responses;
using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Handlers;

public static class GetPersonHandler
{
    public static async Task<IResult> HandleAsync(
        [FromServices] IPersonService personService,
        [FromQuery] Guid id)
    {
        if (id == Guid.Empty)
        {
            return Results.BadRequest(new { Message = "Person Id is required", ErrorCode = 400 });
        }

        var entity = await personService.GetPersonAsync(id.ToString());
        if (entity == null)
        {
            return Results.NotFound(new { Message = "Person not found", ErrorCode = 404 });
        }

        var response = new GetPersonResponse
        {
            Person = new PersonDto
            {
                PersonId = entity.Id,
                FullName = entity.FullName,
                Nickname = entity.Nickname,
                Username = entity.Username,
                Email = entity.Email
            }
        };

        return Results.Ok(response);
    }
}
