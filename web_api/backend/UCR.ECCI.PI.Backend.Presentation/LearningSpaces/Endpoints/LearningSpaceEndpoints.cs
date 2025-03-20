using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Handlers;

namespace UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Endpoints
{
    /// <summary>
    /// Endpoint definitions for the learning space resource.
    /// </summary>
    public static class LearningSpaceEndpoints
    {
        /// <summary>
        /// Method to register the learning space endpoints.
        /// </summary>
        /// <param name="routes"></param>
        /// <returns>The endopoints routes</returns>
        public static IEndpointRouteBuilder RegisterLearningSpaceEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/listlearningspace", ListLearningSpacesHandler.HandleAsync)
                  .WithName("AdminListLearningSpaces()")
                  .WithOpenApi();

            routes.MapPost("/setlearningspace", SetLearningSpaceHandler.HandleAsync)
                  .WithName("SetLearningSpace(LearningSpace)")
                  .WithOpenApi();

            return routes;
        }
    }
}
