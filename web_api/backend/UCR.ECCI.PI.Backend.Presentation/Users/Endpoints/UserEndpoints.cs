using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

using UCR.ECCI.PI.Backend.Presentation.Users.Handlers;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Endpoints;

public static class UserEndpoints
{
    /// <summary>
    /// Method to register the user endpoints.
    /// </summary>
    /// <param name="routes">The route builder.</param>
    /// <returns>The route builder with the user endpoints registered.</returns>
    public static IEndpointRouteBuilder RegisterUserEndpoints(this IEndpointRouteBuilder routes)
    {
        // Endpoint for getting a user by Id
        routes.MapGet("/user", GetUserHandler.HandleAsync)
              .WithName("GetUserById")
              .WithOpenApi();

        // Endpoint for listing all users
        routes.MapGet("/users", ListUsersHandler.HandleAsync)
              .WithName("ListUsers")
              .WithOpenApi();

        // Endpoint for creating a new user
        routes.MapPost("/user", SetUserHandler.HandleAsync)
              .WithName("SetUser")
              .WithOpenApi();

        // Endpoint for changing the user's active status
        routes.MapPut("/user/status", ChangeUserStatusHandler.HandleAsync)
              .WithName("ChangeUserStatus")
              .WithOpenApi();

        return routes;
    }
}
