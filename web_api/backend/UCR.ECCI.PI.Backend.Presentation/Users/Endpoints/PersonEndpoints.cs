using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using UCR.ECCI.PI.Backend.Presentation.Users.Handlers;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Endpoints;

public static class PersonEndpoints
{
    /// <summary>
    /// Method to register the person endpoints.
    /// </summary>
    /// <param name="routes">The route builder.</param>
    /// <returns>The route builder with the person endpoints registered.</returns>
    public static IEndpointRouteBuilder RegisterPersonEndpoints(this IEndpointRouteBuilder routes)
    {
        // Endpoint for getting a person by email
        routes.MapGet("/person", GetPersonHandler.HandleAsync)
              .WithName("GetPersonByEmail")
              .WithOpenApi();

        // Endpoint for listing all persons
        routes.MapGet("/persons", ListPersonsHandler.HandleAsync)
              .WithName("ListPersons")
              .WithOpenApi();

        // Endpoint for creating a new person
        routes.MapPost("/person", SetPersonHandler.HandleAsync)
              .WithName("SetPerson")
              .WithOpenApi();

        // Add more endpoints as necessary for other Person-related actions
        // routes.MapPut("/person/{id}", EditPersonHandler.HandleAsync)
        //    .WithName("EditPerson")
        //    .WithOpenApi();

        return routes;
    }
}
