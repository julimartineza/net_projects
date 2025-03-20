using System.Collections.Generic;
using System.Linq;
using UCR.ECCI.PI.frontend.Domain.Value_Objects;
using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Application.Services
{
    internal class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        private float baseHeight = 5;
        private float altitudeGrowth = 2.5f;


        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        /// <summary>
        /// Retrieves the list of buildings.
        /// </summary>
        /// <returns>The list of buildings.</returns>
        public List<Building> GetBuildings()
        {
            return _buildingRepository.GetBuildings();
        }

        /// <summary>
        /// Sets the height of the building based on the number of floors.
        /// </summary>
        /// <param name="building"></param>
        public void SetBuildingHeight(Building building)
        {
            building.Scale.setHeight(building.floors * baseHeight);
            building.Location.setAltitude(building.floors * altitudeGrowth);
        }
    }
}