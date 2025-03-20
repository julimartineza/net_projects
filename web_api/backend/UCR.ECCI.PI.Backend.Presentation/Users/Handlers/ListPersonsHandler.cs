using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.UserServices;
using UCR.ECCI.PI.Backend.Presentation.Users.Responses;
using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Handlers;

public static class ListPersonsHandler
{
    public static async Task<IResult> HandleAsync(
        [FromServices] IPersonService personService)
    {
        var persons = await personService.ListPersonsAsync();
        if (persons == null || !persons.Any())
        {
            return Results.NotFound(new { Message = "No persons found", ErrorCode = 404 });
        }

        var response = new ListPersonsResponse
        {
            Persons = persons.Select(person => new PersonDto
            {
                PersonId = person.Id,
                FullName = person.FullName,
                Nickname = person.Nickname,
                Username = person.Username,
                Email = person.Email
            }).ToList()
        };

        return Results.Ok(new
        {
            Message = "Persons retrieved successfully",
            StatusCode = 200,
            Data = response
        });
    }
}
