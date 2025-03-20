using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.BuildingServices;
using UCR.ECCI.PI.Backend.Presentation.Buildings.Mappers;
using UCR.ECCI.PI.Backend.Presentation.Buildings.Requests;

namespace UCR.ECCI.PI.Backend.Presentation.Buildings.Handlers;

/// <summary>
/// Handler for the edit building endpoint.
/// </summary>
public static class EditBuildingHandler
{
        /// <summary>
        /// Method to handle the edit building request.
        /// </summary>
        /// <param name="buildingService"></param>
        /// <param name="buildingParams"></param>
        /// <returns>Confirmation of the edited building</returns>
    internal static async Task<IResult> HandleAsync(
        [FromServices] IBuildingService buildingService, [FromBody] SetBuildingRequests buildingParams)
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

            await buildingService.EditBuildingAsync(building);

            var successResponse = new
            {
                Message = "Building edited successfully.",
                StatusCode = 200,
                Details = "The building was edited successfully.",
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
                Message = "Error editing building",
                ErrorCode = 400,
                Details = errorDetails
            };
            return Results.BadRequest(errorResponse);
        }
        catch (KeyNotFoundException knf)
        {
            // Handle "not found" error specifically
            var errorResponse = new
            {
                Message = "Building not found",
                ErrorCode = 404,
                Details = knf.Message
            };
            return Results.NotFound(errorResponse);
        }
    
    }
}
