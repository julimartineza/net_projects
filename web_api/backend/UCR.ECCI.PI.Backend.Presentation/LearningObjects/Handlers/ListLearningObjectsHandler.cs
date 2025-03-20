using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.LearningObjectServices;
using UCR.ECCI.PI.Backend.Domain.LearningObjects.Entities;
using UCR.ECCI.PI.Backend.Presentation.LearningObjects.Mappers;
using UCR.ECCI.PI.Backend.Presentation.LearningObjects.Responses;

namespace UCR.ECCI.PI.Backend.Presentation.LearningObjects.Handlers;

internal static class ListLearningObjectsHandler
{
    /// <summary>
    /// Method to handle the list learning objects request and return the learning objects.
    /// </summary>
    /// <param name="learningObjectService"></param>
    /// <returns>Learning Objects list</returns>
    internal static async Task<ListLearningObjectsResponse> HandleAsync(
        [FromServices] ILearningObjectService learningObjectService)
    {
        IEnumerable<LearningObject> entity = await learningObjectService.ListLearningObjectsAsync();

        var Response = new ListLearningObjectsResponse
        {
            LearningObjects = entity.Select(LearningObjectMapper.ToDto)
        };

        return Response;
    }
}
