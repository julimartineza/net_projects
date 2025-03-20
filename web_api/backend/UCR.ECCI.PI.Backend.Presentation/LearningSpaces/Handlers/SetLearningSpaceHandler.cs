using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.LearningSpacesServices;
using UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Mappers;
using UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Requests;

namespace UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Handlers
{
    /// <summary>
    /// Class to handle the set learning space request.
    /// </summary>
    internal static class SetLearningSpaceHandler
    {
        /// <summary>
        /// Method to handle the set learning space request.
        /// </summary>
        /// <param name="learningSpaceService"></param>
        /// <param name="learningSpaceParams"></param>
        /// <returns>Confirmation when the LearningSpace is created</returns>
        public static async Task<IResult> HandleAsync([FromServices] ILearningSpaceService learningSpaceService, [FromBody] SetLearningSpaceRequest learningSpaceParams)
        {
            var errorResponse = new
            {
                Message = "Invalid input provided.",
                ErrorCode = 400,
                Details = "Missing required field."
            };

            if (learningSpaceParams == null || learningSpaceParams.LearningSpaceDto.Name == null || learningSpaceParams.LearningSpaceDto.Description == null || learningSpaceParams.LearningSpaceDto.TypeLS == null)
            {
                return Results.BadRequest(errorResponse);
            }

            var learningSpace = learningSpaceParams.LearningSpaceDto.ToEntity();

            int result = await learningSpaceService.SetLearningSpaceAsync(learningSpace);

            if (result == 0)
            {
                var response = new
                {
                    Message = "Learning Space created successfully.",
                    StatusCode = 200,
                    Details = "The learning Space was created successfully.",
                    Data = learningSpaceParams
                };
                return Results.Ok(response);
            }
            else if (result == 1)
            {
                errorResponse = new
                {
                    Message = "Database error while creating learning Space.",
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
                    Details = "The learning space could not be created due to an internal error."
                };
                return Results.Problem(detail: errorResponse.Details, statusCode: 500, title: errorResponse.Message);
            }
        }
    }
}

