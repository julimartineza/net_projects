using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.UnitServices;
using UCR.ECCI.PI.Backend.Presentation.Unit.Mappers;
using UCR.ECCI.PI.Backend.Presentation.Unit.Requests;

namespace UCR.ECCI.PI.Backend.Presentation.Unit.Handlers;

    /// <summary>
    /// Class to handle the edit physical unit request.
    /// </summary>
public static class EditPhysicalUnitHandler
{
        /// <summary>
        /// Method to handle the edit physical unit request and edit the physical unit.
        /// </summary>
        /// <param name="physicalUnitService"></param>
        /// <param name="physicalUnitParams"></param>
        /// <returns>Confirmation when the physical unit is edited</returns>
    internal static async Task<IResult> HandleAsync([FromServices] IPhysicalUnitService physicalUnitService, [FromBody] SetPhysicalUnitRequest physicalUnitParams)
    {
        var errorResponse = new
        {
            Message = "Invalid input provided.",
            ErrorCode = 400,
            Details = "Missing required field."
        };

        if (physicalUnitParams == null || physicalUnitParams.PhysicalUnitDto.Name == null)
        {
            return Results.BadRequest(errorResponse);
        }

        try
        {
            var physicalUnit = physicalUnitParams.PhysicalUnitDto.ToEntity();
            await physicalUnitService.EditPhysicalUnitAsync(physicalUnit);
            var successResponse = new
            {
                Message = "PhysicalUnit edited successfully.",
                StatusCode = 200,
                Details = "The physicalUnit was edited successfully.",
                Data = physicalUnitParams
            };
            return Results.Ok(successResponse);
        }
        catch (AggregateException ae)
        {
            // Handle multiple validation errors
            var errorDetails = string.Join(Environment.NewLine, ae.InnerExceptions.Select(e => e.Message));
            var errorResponseInPhysicalUnit = new
            {
                Message = "Error editing PhysicalUnit",
                ErrorCode = 400,
                Details = errorDetails
            };
            return Results.BadRequest(errorResponseInPhysicalUnit);
        }
        catch (KeyNotFoundException knf)
        {
            // Handle "not found" error specifically
            var errorResponseInPhysicalUnit = new
            {
                Message = "PhysicalUnit not found",
                ErrorCode = 404,
                Details = knf.Message
            };
            return Results.NotFound(errorResponseInPhysicalUnit);
        }
    }
}