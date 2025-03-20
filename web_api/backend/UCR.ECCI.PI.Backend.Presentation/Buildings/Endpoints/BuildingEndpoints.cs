using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using UCR.ECCI.PI.Backend.Presentation.Buildings.Handlers;

namespace UCR.ECCI.PI.Backend.Presentation.Buildings.Endpoints
{
      /// <summary>
      /// Defines the endpoints for the building resource.
      /// </summary>
      public static class BuildingEndpoints
      {
            /// <summary>
            /// Method to register the building endpoints.
            /// </summary>
            /// <param name="routes">The route builder.</param>
            /// <returns>The route builder with the building endpoints registered.</returns>
            public static IEndpointRouteBuilder RegisterBuildingEndpoints(this IEndpointRouteBuilder routes)
            {
                  routes.MapGet("/getbuilding", GetBuildingHandler.HandleAsync)
                        .WithName("GetBuilding()")
                        .WithOpenApi();

                  routes.MapGet("/listbuildings", ListBuildingsHandler.HandleAsync)
                        .WithName("AdminListBuildings()")
                        .WithOpenApi();

                  routes.MapPost("/setbuilding", SetBuildingHandler.HandleAsync)
                        .WithName("SetBuilding(Building)")
                        .WithOpenApi();

                  routes.MapPatch("/editbuilding", EditBuildingHandler.HandleAsync)
                        .WithName("EditBuilding(Building)")
                        .WithOpenApi();

                  routes.MapPatch("/buildingStatus", ChangeBuildingStatusHandler.HandleAsync)
                        .WithName("ChangeBuilding(Building)")
                        .WithOpenApi();
                  return routes;
            }
      }
}
