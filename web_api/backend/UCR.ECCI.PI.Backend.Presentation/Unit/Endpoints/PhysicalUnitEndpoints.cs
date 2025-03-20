using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using UCR.ECCI.PI.Backend.Presentation.Unit.Handlers;

namespace UCR.ECCI.PI.Backend.Presentation.Unit.Endpoints
{
    /// <summary>
    /// Defines the endpoints for the physical unit resource.
    /// </summary>
    public static class PhysicalUnitEndpoints
    {
        /// <summary>
        /// Method to register the physical unit endpoints.
        /// </summary>
        /// <param name="routes"></param>
        /// <returns>The endpoints routes</returns>
        public static IEndpointRouteBuilder RegisterPhysicalUnitEndpoints(this IEndpointRouteBuilder routes)
        {

            routes.MapPost("/setphysicalUnit", SetPhysicalUnitHandler.HandleAsync)
                  .WithName("SetPhysicalUnit(PhysicalUnit)")
                  .WithOpenApi();

            routes.MapPatch("/editphysicalUnit", EditPhysicalUnitHandler.HandleAsync)
               .WithName("EditPhysicalUnit(PhysicalUnit)")
               .WithOpenApi();

            routes.MapPatch("/physicalUnitStatus", ChangePhysicalUnitStatusHandler.HandleAsync)
              .WithName("ChangePhysicalUnitStatus(AdministrativeUnitActiveStatus)")
              .WithOpenApi();

            return routes;
        }
    }
}
