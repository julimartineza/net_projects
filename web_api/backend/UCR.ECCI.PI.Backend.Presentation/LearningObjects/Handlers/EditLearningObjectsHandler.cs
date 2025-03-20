using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.LearningObjectServices;
using UCR.ECCI.PI.Backend.Presentation.LearningObjects.Mappers;
using UCR.ECCI.PI.Backend.Presentation.LearningObjects.Requests;

namespace UCR.ECCI.PI.Backend.Presentation.LearningObjects.Handlers;

class EditLearningObjectsHandler
{

    /// <summary>
    /// Method to handle the edit Learning Object request.
    /// </summary>
    /// <param name="learningObjectService"></param>
    /// <param name="learningObjectParams"></param>
    /// <returns>Confirmation of the edited LearningObject</returns>
    /// 
  
    internal static async Task<IResult> HandleAsync(
        [FromServices] ILearningObjectService learningObjectService, [FromBody] EditLearningObjectRequest learningObjectsParams)
    {
        // Initial validation
        if (learningObjectsParams == null || learningObjectsParams.LearningObjectDto.Id == null)
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

            var learningObject = learningObjectsParams.LearningObjectDto.ToEntity();

            await learningObjectService.EditLearningObjectAsync(learningObject);

            var successResponse = new
            {
                Message = "Learning edited successfully.",
                StatusCode = 200,
                Details = "The Learning Object was edited successfully.",
        
            };
            return Results.Ok(successResponse);
        }
        catch (AggregateException ae)
        {
            // Handle multiple validation errors
            var errorDetails = string.Join("\n", ae.InnerExceptions.Select(e => e.Message));
            var errorResponse = new
            {
                Message = "Error editing Learning",
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
                Message = "LearningObject not found",
                ErrorCode = 404,
                Details = knf.Message
            };
            return Results.NotFound(errorResponse);
        }
        catch (Exception ex)
        {
            // Captura de otros errores inesperados
            var errorResponse = new
            {
                Message = "Ocurrió un error inesperado al procesar su solicitud.",
                ErrorCode = 500,
                Details = ex.Message
            };
            return Results.NotFound(errorResponse);
        }

    }
}







