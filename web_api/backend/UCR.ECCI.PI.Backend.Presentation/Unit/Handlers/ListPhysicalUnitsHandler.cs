using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.UnitServices;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Presentation.Unit.Mappers;
using UCR.ECCI.PI.Backend.Presentation.Unit.Response;

namespace UCR.ECCI.PI.Backend.Presentation.Unit.Handlers
{
    /// <summary>
    /// Class to handle the list physical unit request.
    /// </summary>
    internal static class ListPhysicalUnitHandler
    {


        /// <summary>
        /// Method to handle the list physical unit request and return the physical units.
        /// </summary>
        /// <param name="physicalUnitService"> The building service.</param>
        /// <returns>The list of the physical units.</returns>
        internal static async Task<ListPhysicalUnitResponse> HandleAsync(
            [FromServices] IPhysicalUnitService physicalUnitService
        )
        {
            var entity = await physicalUnitService.ListPhysicalUnitAsync();
            var Response = new ListPhysicalUnitResponse
            {
                PhysicalUnits = entity.Select(PhysicalUnitMapper.ToDto)
            };
            return Response;
        }
    }
}
