using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using UCR.ECCI.PI.Backend.Presentation.Unit.Handlers;

namespace UCR.ECCI.PI.Backend.Presentation.Unit.Endpoints;

/// <summary>
/// Defines the endpoints for the administrative unit resource.
/// </summary>
public static class AdministrativeUnitEndpoints
{
      /// <summary>
      /// Method to register the administrative unit endpoints.
      /// </summary>
      /// <param name="routes"></param>
      /// <returns>The endpoints routes</returns>
      public static IEndpointRouteBuilder RegisterAdministrativeUnitEndpoints(this IEndpointRouteBuilder routes)
      {
            routes.MapPost("/setAdministrativeUnit", SetAdministrativeUnitHandler.HandleAsync)
                  .WithName("SetAdministrativeUnit(AdministrativeUnit)")
                  .WithOpenApi()
                  .RequireAuthorization();

            routes.MapPatch("/editAdministrativeUnit", UpdateAdministrativeUnitHandler.HandleAsync)
                  .WithName("UpdateAdministrativeUnit(AdministrativeUnit)")
                  .WithOpenApi()
                  .RequireAuthorization();

            routes.MapPatch("/changeAdministrativeUnitStatus", ChangeAdministrativeUnitStatusHandler.HandleAsync)
                  .WithName("ChangeAdministrativeUnitStatus(AdministrativeUnitActiveStatus)")
                  .WithOpenApi()
                  .RequireAuthorization();

            return routes;
      }
}
