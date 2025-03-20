using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.LearningObjectServices;
using UCR.ECCI.PI.Backend.Presentation.LearningObjects.Mappers;
using UCR.ECCI.PI.Backend.Presentation.LearningObjects.Requests;

namespace UCR.ECCI.PI.Backend.Presentation.LearningObjects.Handlers
{
    internal static class SetLearningObjectHandler
    {
        /// <summary>
        /// Method to handle the set learning space request.
        /// </summary>
        /// <param name="learningObjectService"></param>
        /// <param name="learningObjectsParams"></param>
        /// <returns>Confirmation when the LearningSpace is created</returns>
        public static async Task<IResult> HandleAsync([FromServices] ILearningObjectService learningObjectService, [FromBody] SetLearningObjectRequest learningObjectsParams)
        {
            var errorResponse = new
            {
                Message = "Invalid input provided.",
                ErrorCode = 400,
                Details = "Missing required Field."
            };

            if (learningObjectsParams == null || learningObjectsParams.LearningObjectDto.Id == null)
            {

                return Results.BadRequest(errorResponse);
            }

            var learningObject = learningObjectsParams.LearningObjectDto.ToEntity();

            int state = await learningObjectService.SetLearningObjectAsync(learningObject);
            string errorString = string.Empty;
            switch (state)
            {
                case 1:
                    errorString = "Invalid Name";
                    break;

                case 2:
                    errorString = "Invalid Description";
                    break;
                case 3:
                    errorString = "Invalid X size";
                    break;
                case 4:
                    errorString = "Invalid Y size";
                    break;
                case 5:
                    errorString = "Invalid Z size";
                    break;
                case 6:
                    errorString = "Invalid Type";
                    break;
                case 7:
                    errorString = "Invalid Floor amount";
                    break;
            }

            if (state == 0)
            {
                var Response = new
                {
                    Message = "Learning Space created successfully.",
                    StatusCode = 200,
                    Details = "The Learning Space was created successfully.",
                    Data = learningObjectsParams
                };
                return Results.Ok(Response);
            }

            else
            {
                errorResponse = new
                {
                    Message = "Error creating Learning Space: " + errorString,
                    ErrorCode = 409,
                    Details = "The Learning Space could not be created. Possible duplicate Name."
                };
                return Results.BadRequest(errorResponse);
            }
        }
    }
}
