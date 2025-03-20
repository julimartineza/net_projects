using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.UserServices;
using UCR.ECCI.PI.Backend.Presentation.Users.Requests;
using UCR.ECCI.PI.Backend.Presentation.Users.Responses;
using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Handlers;

public static class SetPersonHandler
{
    internal static async Task<IResult> HandleAsync(
        [FromServices] IPersonService personService,
        [FromBody] SetPersonRequest personRequest)
    {
        if (personRequest == null || personRequest.PersonDto == null ||
            string.IsNullOrEmpty(personRequest.PersonDto.FullName) || string.IsNullOrEmpty(personRequest.PersonDto.Email))
        {
            return Results.BadRequest(new
            {
                Message = "Invalid input",
                ErrorCode = 400,
                Details = "Missing required fields"
            });
        }

        try
        {
            // Map PersonDto to SetPersonParams
            SetPersonParams personParams = new SetPersonParams(
                personRequest.PersonDto.PersonId,  // Assuming Id is part of PersonDto
                personRequest.PersonDto.FullName,  // Assuming FullName is part of PersonDto
                personRequest.PersonDto.Nickname,  // Assuming Nickname is part of PersonDto
                personRequest.PersonDto.Username,  // Assuming Username is part of PersonDto
                personRequest.PersonDto.Email    // Assuming Email is part of PersonDto
            );

            // Call service with the mapped parameters
            await personService.SetPersonAsync(personParams);

            var response = new SetPersonResponse
            {
                Person = personRequest.PersonDto
            };

            return Results.Created($"/persons/", response);
        }
        catch (AggregateException ex)
        {
            var errorDetails = string.Join("\n", ex.InnerExceptions.Select(e => e.Message));
            return Results.BadRequest(new
            {
                Message = "Error creating person",
                ErrorCode = 400,
                Details = errorDetails
            });
        }
    }
}
