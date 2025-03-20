using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.UnitServices;
using UCR.ECCI.PI.Backend.Presentation.Unit.Requests;
using UCR.ECCI.PI.Backend.Presentation.Unit.Mappers;

namespace UCR.ECCI.PI.Backend.Presentation.Unit.Handlers;

/// <summary>
/// Class to handle the edit administrative unit request.
/// </summary>
public static class UpdateAdministrativeUnitHandler
{
     /// <summary>
    /// Method to handle the edit administrative unit request and edit the administrative unit.
    /// </summary>
    /// <param name="administrativeUnitService"></param>
    /// <param name="administrativeUnitParams"></param>
    /// <returns>Confirmation when the administative unit is edited</returns>
    internal static async Task<IResult> HandleAsync([FromServices] IAdministrativeUnitService administrativeUnitService, [FromBody] SetAdministrativeUnitRequest administrativeUnitParams)
    {
        var errorResponse = new
        {
            Message = "Invalid input provided.",
            ErrorCode = 400,
            Details = "Missing required field."
        };

        if (administrativeUnitParams == null || administrativeUnitParams.AdministrativeUnitDto.Name == null)
        {
            return Results.BadRequest(errorResponse);
        }

        try
        {
            var administrativeUnit = administrativeUnitParams.AdministrativeUnitDto.ToEntity();
            await administrativeUnitService.EditAdministrativeUnitAsync(administrativeUnit);
            var successResponse = new
            {
                Message = "Administrative unit edited successfully.",
                StatusCode = 200,
                Details = "The administrative unit was edited successfully.",
                Data = administrativeUnitParams
            };
            return Results.Ok(successResponse);
        }
        catch (AggregateException ae)
        {
            // Handle multiple validation errors
            var errorDetails = string.Join(Environment.NewLine, ae.InnerExceptions.Select(e => e.Message));
            var validationErrorResponse = new
            {
                Message = "Error editing Administrative Unit",
                ErrorCode = 400,
                Details = errorDetails
            };
            return Results.BadRequest(validationErrorResponse);
        }
        catch (KeyNotFoundException knf)
        {
            // Handle "not found" error specifically
            var notFoundErrorResponse = new
            {
                Message = "Administrative Unit not found",
                ErrorCode = 404,
                Details = knf.Message
            };
            return Results.NotFound(notFoundErrorResponse);
        }
    }
}