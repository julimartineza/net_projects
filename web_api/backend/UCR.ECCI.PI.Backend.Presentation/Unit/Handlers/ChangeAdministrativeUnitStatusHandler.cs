using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.UnitServices;
using UCR.ECCI.PI.Backend.Domain.Unit.Records;

namespace UCR.ECCI.PI.Backend.Presentation.Unit.Handlers;

/// <summary>
/// Class to handle the change administrative unit status request.
/// </summary>
public static class ChangeAdministrativeUnitStatusHandler
{
    /// <summary>
    /// Method to handle the change administrative unit status request and change the status of the administrative unit.
    /// </summary>
    /// <param name="administrativeUnitService"></param>
    /// <param name="desiredStatus"></param>
    /// <param name="name"></param>
    /// <returns>Confirmation when the administrative unit status changes</returns>
    public static async Task<IResult> HandleAsync([FromServices] IAdministrativeUnitService administrativeUnitService, [FromQuery] bool desiredStatus, [FromQuery] string name)
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
            AdministrativeUnitActiveStatus administrativeUnitActiveStatus = new AdministrativeUnitActiveStatus(name, desiredStatus);

            await administrativeUnitService.ChangeAdministrativeUnitStatusAsync(administrativeUnitActiveStatus);
        }
        catch (Exception e)
        {
            errorResponse = new
            {
                Message = "Error editing Administrative Unit: " + errorString,
                ErrorCode = 409,
                Details = "The Administrative Unit could not be edited. \r\n" + e.Message
            };
            return Results.BadRequest(errorResponse);
        }

        var Response = new
        {
            Message = "Administrative Unit edited successfully.",
            StatusCode = 200,
            Details = "The Administrative Unit was edited successfully.",
            Data = name
        };
        return Results.Ok(Response);


    }
}

