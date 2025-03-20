using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.BuildingServices;
using UCR.ECCI.PI.Backend.Application.TreeServices;
using UCR.ECCI.PI.Backend.Presentation.Buildings.Mappers;
using UCR.ECCI.PI.Backend.Presentation.Trees.Mappers;
using UCR.ECCI.PI.Backend.Presentation.Trees.Responses;

namespace UCR.ECCI.PI.Backend.Presentation.Trees.Handlers;

internal static class ListTreesHandler
{

    /// <summary>
    /// Method to handle the list buildings request and return the list of buildings on the system.
    /// </summary>
    /// <param name="buildingService">The building service.</param>
    /// <returns>The list of buildings.</returns>
    public static async Task<GetTreeResponse> HandleAsync(
        [FromServices] ITreeService treeService)
    {

        var entity = await treeService.GetTrees();
        return new GetTreeResponse
        {
            Trees = entity.Select(TreeMapper.ToDto)
        };
    }
}
