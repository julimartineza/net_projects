using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.Buildings.Repositories;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

namespace UCR.ECCI.PI.Backend.Infrastructure.EntityBuilding.Repositories
{
    /// <summary>
    /// Repository for buildings.
    /// </summary>
    internal class BuildingRepository : IBuildingRepository
    {
        private DatabaseContext _databaseContext { get; set; }

        /// <summary>
        /// Building repository constructor.
        /// </summary>
        /// <param name="databaseContext"></param>
        public BuildingRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///  Implements the method in the IBuildingRepository interface to get a building by its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Building object</returns>
        public async Task<IEnumerable<Building>> GetBuildingAsync(string name)
        {
            return await _databaseContext.GetBuildingsByName(name).ToListAsync();
        }

        /// <summary>
        /// Implements the method in the IBuildingRepository interface to get a building by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Building Object</returns>
        public async Task<Building?> GetBuildingByIdAsync(Id id)
        {
            return await _databaseContext.Building.FindAsync(id);
        }

        /// <summary>
        /// Implements the method in the IBuildingRepository interface to list all buildings.
        /// </summary>
        /// <returns>List of Buildings objects</returns>
        public async Task<IEnumerable<Building>> ListBuildingsAsync()
        {
            var buildings = await _databaseContext.GetAllBuildingsHierarchy()
                        .ToListAsync();

            return buildings.AsEnumerable();
        }

        /// <summary>
        /// Implements the method in the IBuildingRepository interface to set a building.
        /// </summary>
        /// <param name="building"></param>
        /// <returns>0 when successful</returns>
        public async Task<int> SetBuildingAsync(Building building)
        {
            _databaseContext.Building.Add(building);
            await _databaseContext.SaveChangesAsync();
            return 0;
        }

        /// <summary>
        /// Implements the method in the IBuildingRepository interface to edit a building.
        /// </summary>
        /// <param name="building"></param>
        /// <returns>0 when successful</returns>
        public async Task<int> EditBuildingAsync(Building building)
        {
            _databaseContext.Building.Update(building);
            await _databaseContext.SaveChangesAsync();
            return 0;
        }
    }
}