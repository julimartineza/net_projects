using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.UnitServices;
using UCR.ECCI.PI.Backend.Domain.Unit.Records;

namespace UCR.ECCI.PI.Backend.Presentation.Unit.Handlers;

/// <summary>
/// Class to handle the change physical unit status request.
/// </summary>
public static class ChangePhysicalUnitStatusHandler
{
    /// <summary>
    /// Method to handle the change physical unit status request and change the status of the physical unit.
    /// </summary>
    /// <param name="physicalUnitService"></param>
    /// <param name="desiredStatus"></param>
    /// <param name="name"></param>
    /// <returns>Confirmation when the physical unit status changes</returns>
    public static async Task<IResult> HandleAsync([FromServices] IPhysicalUnitService physicalUnitService, [FromQuery] bool desiredStatus, [FromQuery] string name)
    {
        var errorResponse = new
        {
            Message = "Invalid input provided.",
            ErrorCode = 400,
            Details = "Missing required Field."
        };

        if (name == null)
        {

            return Results.BadRequest(errorResponse);
        }
        string errorString = string.Empty;
        try
        {
            AdministrativeUnitActiveStatus physicalUnitActiveStatus = new AdministrativeUnitActiveStatus(name, desiredStatus);

            await physicalUnitService.ChangePhysicalUnitStatusAsync(physicalUnitActiveStatus);
        }
        catch (Exception e)
        {
            errorResponse = new
            {
                Message = "Error editing Physical Unit: " + errorString,
                ErrorCode = 409,
                Details = "The Physical Unit could not be edited. \r\n" + e.Message
            };
            return Results.BadRequest(errorResponse);
        }

        var Response = new
        {
            Message = "Physical Unit edited successfully.",
            StatusCode = 200,
            Details = "The Physical Unit was edited successfully.",
            Data = name
        };
        return Results.Ok(Response);


    }
}