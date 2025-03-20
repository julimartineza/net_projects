using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using UCR.ECCI.PI.Backend.Presentation.Trees.Handlers;

namespace UCR.ECCI.PI.Backend.Presentation.Trees.Endpoints;

public static class TreeEndpoints
{
    public static IEndpointRouteBuilder RegisterTreeEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/listtrees", ListTreesHandler.HandleAsync)
             .WithName("GetTrees")
             .WithOpenApi();

        routes.MapPost("/settree", SetTreeHandler.HandleAsync)
             .WithName("SetTree(Tree)")
             .WithOpenApi();

        return routes;


    }
}
