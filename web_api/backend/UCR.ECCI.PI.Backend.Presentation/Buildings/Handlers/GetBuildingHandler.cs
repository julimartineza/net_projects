using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.BuildingServices;
using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Presentation.Buildings.Mappers;
using UCR.ECCI.PI.Backend.Presentation.Buildings.Responses;

namespace UCR.ECCI.PI.Backend.Presentation.Buildings.Handlers
{
    /// <summary>
    /// Class to handle the get building request.
    /// </summary>
    internal static class GetBuildingHandler
    {

        /// <summary>
        /// Method to handle the get building request and return the building information.
        /// </summary>
        /// <param name="buildingService"> The building service.</param>
        /// <param name="search">Name of the building to search.</param>
        /// <returns>The information of the building.</returns>
        internal static async Task<GetBuildingListResponse> HandleAsync(
            [FromServices] IBuildingService buildingService,
            [FromQuery] string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                IEnumerable<Building> entity = await buildingService.GetBuildingAsync(search);
                var Response = new GetBuildingListResponse
                {
                    Buildings = entity.Select(BuildingMapper.ToDto)
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
