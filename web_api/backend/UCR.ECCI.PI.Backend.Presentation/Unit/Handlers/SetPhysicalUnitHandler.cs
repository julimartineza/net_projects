using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.UnitServices;
using UCR.ECCI.PI.Backend.Presentation.Unit.Mappers;
using UCR.ECCI.PI.Backend.Presentation.Unit.Requests;

namespace UCR.ECCI.PI.Backend.Presentation.Unit.Handlers
{
    /// <summary>
    /// Class to handle the set physical unit request.
    /// </summary>
    internal static class SetPhysicalUnitHandler
    {
        /// <summary>
        /// Method to handle the set physical unit request and register a new physical unit in the system.
        /// </summary>
        /// <param name="physicalUnitService">The physical unit service.</param>
        /// <param name="physicalUnitParams">The parameters to set the physical unit's information.</param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            [FromServices] IPhysicalUnitService physicalUnitService,
            [FromBody] SetPhysicalUnitRequest physicalUnitParams)
        {
            // Initial validation
            if (physicalUnitParams == null || physicalUnitParams.PhysicalUnitDto.Name == null)
            {
                var validationError = new
                {
                    Message = "Invalid input provided.",
                    ErrorCode = 400,
                    Details = "Missing required fields."
                };
                return Results.BadRequest(validationError);
            }

            var physicalUnit = physicalUnitParams.PhysicalUnitDto.ToEntity();

            var result = await physicalUnitService.SetPhysicalUnitAsync(physicalUnit);

            if (result == 0)
            {
                var response = new
                {
                    Message = "Administrative Unit created successfully.",
                    StatusCode = 200,
                    Details = "The administrative unit was created successfully.",
                    Data = physicalUnitParams
                };
                return Results.Ok(response);
            }
            else if (result == 1)
            {
                var errorResponse = new
                {
                    Message = "Database error while creating administrative unit.",
                    ErrorCode = 409,
                    Details = "There might be a duplicate Name or database constraint violation."
                };
                return Results.Conflict(errorResponse);
            }
            else
            {
                var errorResponse = new
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
