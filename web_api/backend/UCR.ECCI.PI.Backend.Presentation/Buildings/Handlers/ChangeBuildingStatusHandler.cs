using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.BuildingServices;

namespace UCR.ECCI.PI.Backend.Presentation.Buildings.Handlers
{
    /// <summary>
    /// Handler for the change building status endpoint.
    /// </summary>
    public static class ChangeBuildingStatusHandler
    {
        /// <summary>
        /// Method to handle the change building status request.
        /// </summary>
        /// <param name="buildingService"></param>
        /// <param name="desiredStatus"></param>
        /// <param name="id"></param>
        /// <returns>Confirmation of the edited building status</returns>
        public static async Task<IResult> HandleAsync([FromServices] IBuildingService buildingService, [FromQuery] bool desiredStatus, [FromQuery] string id)
        {
            var errorResponse = new
            {
                Message = "Invalid input provided.",
                ErrorCode = 400,
                Details = "Missing required Field."
            };

            if (id == null)
            {

                return Results.BadRequest(errorResponse);
            }
            string errorString = string.Empty;
            try
            {
                await buildingService.ChangeBuildingStatusAsync(id, desiredStatus);
            }
            catch (Exception e)
            {
                errorResponse = new
                {
                    Message = "Error editing building: " + errorString,
                    ErrorCode = 409,
                    Details = "The building could not be edited. \r\n" + e.Message
                };
                return Results.BadRequest(errorResponse);
            }

            var Response = new
            {
                Message = "Building edited successfully.",
                StatusCode = 200,
                Details = "The building was edited successfully.",
                Data = id
            };
            return Results.Ok(Response);


        }
    }
}

