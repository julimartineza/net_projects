using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;

namespace UCR.ECCI.PI.Backend.Application.BuildingServices;

/// <summary>
/// Interface for the Building Service.
/// </summary>
public interface IBuildingService
{
    public Task<IEnumerable<Building>> GetBuildingAsync(string search);

    // <Summary>
    // List all buildings in the system.
    // </Summary>
    public Task<IEnumerable<Building>> ListBuildingsAsync();

    // <Summary>
    // Set a building in the system.
    // </Summary>
    // <param name="newBuilding">The building to set.</param>
    public Task<int> SetBuildingAsync(Building newBuilding);

    /// <summary>
    /// Edit a building in the system.
    /// </summary>
    /// <param name="newBuilding"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<int> EditBuildingAsync(Building newBuilding);

    /// <summary>
    /// Change the status of a building.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="desiredStatus"></param>
    /// <returns></returns>
    public Task<int> ChangeBuildingStatusAsync(string id, bool desiredStatus);
}

