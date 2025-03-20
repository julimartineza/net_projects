using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.BuildingServices;
using UCR.ECCI.PI.Backend.Presentation.Buildings.Mappers;
using UCR.ECCI.PI.Backend.Presentation.Buildings.Requests;

namespace UCR.ECCI.PI.Backend.Presentation.Buildings.Handlers;

/// <summary>
/// Class to handle the set building request.
/// </summary>
public static class SetBuildingHandler
{

    /// <summary>
    /// Method to handle the set building request and register a new building on the system.
    /// </summary>
    /// <param name="buildingService">The building service.</param>
    /// <param name="buildingParams">The parameters to set the building's information.</param>
    /// <returns></returns>
    internal static async Task<IResult> HandleAsync(
        [FromServices] IBuildingService buildingService,
        [FromBody] SetBuildingRequests buildingParams)
    {
        // Initial validation
        if (buildingParams == null || buildingParams.BuildingDto.Name == null || buildingParams.BuildingDto.Id == null)
        {
            var validationError = new
            {
                Message = "Invalid input provided.",
                ErrorCode = 400,
                Details = "Missing required fields."
            };
            return Results.BadRequest(validationError);
        }

        try
        {
            var building = buildingParams.BuildingDto.ToEntity();

            await buildingService.SetBuildingAsync(building);

            var successResponse = new
            {
                Message = "Building created successfully.",
                StatusCode = 200,
                Details = "The building was created successfully.",
                Data = buildingParams
            };
            return Results.Ok(successResponse);
        }
        catch (AggregateException ae)
        {
            // Handle multiple validation errors
            var errorDetails = string.Join("\n", ae.InnerExceptions.Select(e => e.Message));
            var errorResponse = new
            {
                Message = "Error creating building",
                ErrorCode = 400,
                Details = errorDetails
            };
            return Results.BadRequest(errorResponse);
        }
    }
}
