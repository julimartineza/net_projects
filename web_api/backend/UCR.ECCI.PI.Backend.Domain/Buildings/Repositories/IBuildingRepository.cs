using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

namespace UCR.ECCI.PI.Backend.Domain.Buildings.Repositories;

/// <summary>
/// A repository for managing buildings.
/// </summary>
public interface IBuildingRepository
{
    /// <summary>
    /// Retrieves a building attributes by its name.Matches similar @param name names in the database.
    /// </summary>
    /// <param name="name">The name of the building to search.</param>
    /// <returns>A collection of buildings with the specified name.</returns>
    public Task<IEnumerable<Building>> GetBuildingAsync(string name);

    public Task<Building?> GetBuildingByIdAsync(Id id);

    /// <summary>
    /// Retrieves all buildings with its information.
    /// </summary>
    /// <returns>A collection of all buildings.</returns>

    public Task<IEnumerable<Building>> ListBuildingsAsync();

    /// <summary>
    /// Sets a building.
    /// </summary>
    /// <param Building="building">The building to set.</param>
    /// <returns>The number of buildings affected.</returns>
    public Task<int> SetBuildingAsync(Building building);

    /// <summary>
    /// Edits a building
    /// </summary>
    /// <param Building="building"></param>
    /// <returns>  0 when edited succesfully </returns>
    public Task<int> EditBuildingAsync(Building building);
}
