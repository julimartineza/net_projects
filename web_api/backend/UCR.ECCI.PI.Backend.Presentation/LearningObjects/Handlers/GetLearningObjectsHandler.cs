using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.BuildingServices;
using UCR.ECCI.PI.Backend.Application.LearningObjectServices;
using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningObjects.Entities;
using UCR.ECCI.PI.Backend.Presentation.LearningObjects.Mappers;
using UCR.ECCI.PI.Backend.Presentation.LearningObjects.Responses;

namespace UCR.ECCI.PI.Backend.Presentation.LearningObjects.Handlers;

/// <summary>
/// Class to handle the get building request.
/// </summary>
public static class GetLearningObjectsHandler
{

    /// <summary>
    /// Method to handle the get building request and return the building information.
    /// </summary>
    /// <param name="buildingService"> The building service.</param>
    /// <param name="search">Name of the building to search.</param>
    /// <returns>The information of the building.</returns>
    public static async Task<IResult> HandleAsync(
        [FromServices] ILearningObjectService buildingService,
        [FromQuery] string search)
    {
        if (string.IsNullOrEmpty(search))
        {
            return Results.BadRequest("Data to search is required");
        }

        IEnumerable<LearningObject> entity = await buildingService.GetLearningObjectsAsync(search);
        var Response = new ListLearningObjectsResponse
        {
            LearningObjects = entity.Select(LearningObjectMapper.ToDto)
        };
        return Results.Ok(Response);
    }
}
