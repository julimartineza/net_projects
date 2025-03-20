using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using UCR.ECCI.PI.Backend.Presentation.LearningObjects.Handlers;

namespace UCR.ECCI.PI.Backend.Presentation.LearningObjects.Endpoints;

public static class LearningObjectsEndpoints
{
    /// <summary>
    /// Method to register the learning space endpoints.
    /// </summary>
    /// <param name="routes"></param>
    /// <returns>The endopoints routes</returns>
    public static IEndpointRouteBuilder RegisterLearningObjectEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/listlearningobject", ListLearningObjectsHandler.HandleAsync)
              .WithName("ListLearningObjects()")
              .WithOpenApi();

        routes.MapPost("/setlearningobjects", SetLearningObjectHandler.HandleAsync)
              .WithName("SetLearningObjects(LearningObject)")
              .WithOpenApi();

        routes.MapGet("/getlearningobjects", GetLearningObjectsHandler.HandleAsync)
              .WithName("GetLearningObjects(search)")
              .WithOpenApi();

        routes.MapPatch("/editlearningobject", EditLearningObjectsHandler.HandleAsync)
              .WithName("EditLearningObject(LearningObject)")
              .WithOpenApi();

        return routes;
    }
}
