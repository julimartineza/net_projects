using UCR.ECCI.PI.Backend.Presentation.Buildings.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Buildings.Requests;

/// <summary>
/// Record representing the request to create a building
/// </summary>
internal record SetBuildingRequests
{
    /// <summary>
    /// Dto representing the building
    /// </summary>
    public required BuildingDto BuildingDto { get; init; }
}
