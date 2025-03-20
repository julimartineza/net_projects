using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.LearningSpacesServices;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Entities;
using UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Mappers;
using UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Responses;

namespace UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Handlers
{
    /// <summary>
    /// Class to handle the list learning spaces request.
    /// </summary>
    internal static class ListLearningSpacesHandler
    {
        /// <summary>
        /// Method to handle the list learning spaces request and return the learning spaces.
        /// </summary>
        /// <param name="buildingService"></param>
        /// <param name="id"></param>
        /// <returns>Learning Spaces list</returns>
        internal static async Task<ListLearningSpacesResponse> HandleAsync(
            [FromServices] ILearningSpaceService buildingService,
            [FromQuery] string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var entity = await buildingService.ListLearningSpacesAsync(id);

                var Response = new ListLearningSpacesResponse
                {
                    LearningSpaces = entity.Select(LearningSpaceMapper.ToDto)
                };
                return Response;
            }
            else
            {
                return null;
            }
        }
    }
}
