using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.BuildingServices;
using UCR.ECCI.PI.Backend.Presentation.Buildings.Dtos;
using UCR.ECCI.PI.Backend.Presentation.Buildings.Mappers;
using UCR.ECCI.PI.Backend.Presentation.Buildings.Responses;

namespace UCR.ECCI.PI.Backend.Presentation.Buildings.Handlers
{   
    /// <summary>
    /// Class to handle the list buildings request.
    /// </summary>
    internal static class ListBuildingsHandler
    {

        /// <summary>
        /// Method to handle the list buildings request and return the list of buildings on the system.
        /// </summary>
        /// <param name="buildingService">The building service.</param>
        /// <returns>The list of buildings.</returns>
        public static async Task<GetBuildingListResponse> HandleAsync(
            [FromServices] IBuildingService buildingService)
        {

            var entity = await buildingService.ListBuildingsAsync();
            return new GetBuildingListResponse
            {
                Buildings = entity.Select(BuildingMapper.ToDto)
            };
        }
    }
}
