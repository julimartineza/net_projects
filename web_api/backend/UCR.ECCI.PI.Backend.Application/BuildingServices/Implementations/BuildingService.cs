using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.Buildings.Repositories;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Unit.Repositories;
using UCR.ECCI.PI.Backend.Domain.Unit.Records;
using Microsoft.VisualBasic;

namespace UCR.ECCI.PI.Backend.Application.BuildingServices.Implementations
{
    // <summary>
    // Represents the service for managing buildings.
    // </summary>
    internal class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingEntityRepository;

        public BuildingService(IBuildingRepository buildingServiceRepository, IAdministrativeUnitRepository administrativeUnitServiceRepository)
        {
            _buildingEntityRepository = buildingServiceRepository;

        }

        // <summary>
        // Get a building by its name.
        // </summary>
        // <param name="name">The name of the building to get.</param>
        public async Task<IEnumerable<Building>> GetBuildingAsync(string search)
        {
            return await _buildingEntityRepository.GetBuildingAsync(search);
        }

        // <summary>
        // List all buildings in the system.
        // </summary>
        public async Task<IEnumerable<Building>> ListBuildingsAsync()
        {
            var result = await _buildingEntityRepository.ListBuildingsAsync();
            return result;
        }

        // <summary>
        // Set a building in the system.
        // </summary>
        // <param name="newBuilding">The building to set.</param>
        public async Task<int> SetBuildingAsync(Building newBuilding)
        {
            return await _buildingEntityRepository.SetBuildingAsync(newBuilding);
        }

        public async Task<int> EditBuildingAsync(Building newBuilding)
        {
            // Initialize a list to store all validation errors that may occur during the process
            var errors = new List<string>();

            // Validate if the building to edit exists in the database
            Id searchId = Id.Create(newBuilding.Id.Value);
            var existingBuilding = await _buildingEntityRepository.GetBuildingByIdAsync(searchId);

            if (existingBuilding == null)
            {
                var errorMessage = $"Building with ID {searchId} not found.";
                /* Please note that in addition to being handled as a separate error,
                    the message is also being added to the general error list, so it can be handled from there. */
                errors.Add(errorMessage);
                throw new KeyNotFoundException(errorMessage);
            }

            return await _buildingEntityRepository.EditBuildingAsync(newBuilding);
        }

        /// <summary>
        /// Change the status of a building.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="desiredStatus"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<int> ChangeBuildingStatusAsync(string id, bool desiredStatus)
        {
            // It is checked whether the building for which you want to edit the information exists in the database
            Id searchId = Id.Create(id);
            var existingBuilding = await _buildingEntityRepository.GetBuildingByIdAsync(searchId);

            if (existingBuilding == null)
            {
                throw new KeyNotFoundException($"Building with ID {id} not found.");
            }
            existingBuilding.Status = desiredStatus;

            return await _buildingEntityRepository.EditBuildingAsync(existingBuilding);
        }
    }
}
