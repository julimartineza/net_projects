using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.UnitServices;
using UCR.ECCI.PI.Backend.Presentation.Unit.Mappers;
using UCR.ECCI.PI.Backend.Presentation.Unit.Requests;

namespace UCR.ECCI.PI.Backend.Presentation.Unit.Handlers
{
    /// <summary>
    /// Class to handle the set administrative unit request.
    /// </summary>
    public static class SetAdministrativeUnitHandler
    {
        /// <summary>
        /// Method to handle the set administrative unit request and create a new administrative unit.
        /// </summary>
        /// <param name="administrativeUnitService"></param>
        /// <param name="administrativeUnitParams"></param>
        /// <returns>Confirmation when the administrative unit is created</returns>
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
            var administrativeUnit = administrativeUnitParams.AdministrativeUnitDto.ToEntity();
            var administrativeUnitLocatedIn = administrativeUnitParams.AdministrativeUnitDto.ToLocationEntity();
            int result = await administrativeUnitService.SetAdministrativeUnitAsync(administrativeUnit, administrativeUnitLocatedIn);

            if (result == 0)
            {
                var response = new
                {
                    Message = "Administrative Unit created successfully.",
                    StatusCode = 200,
                    Details = "The administrative unit was created successfully.",
                    Data = administrativeUnitParams
                };
                return Results.Ok(response);
            }
            else if (result == 1)
            {
                errorResponse = new
                {
                    Message = "Database error while creating administrative unit.",
                    ErrorCode = 409,
                    Details = "There might be a duplicate Name or database constraint violation."
                };
                return Results.Conflict(errorResponse);
            }
            else
            {
                errorResponse = new
                {
                    Message = "An unknown error occurred.",
                    ErrorCode = 500,
                    Details = "The administrative unit could not be created due to an internal error."
                };
                return Results.Problem(detail: errorResponse.Details, statusCode: 500, title: errorResponse.Message);
            }
        }
    }
}