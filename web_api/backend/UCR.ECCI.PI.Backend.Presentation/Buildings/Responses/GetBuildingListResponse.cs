using UCR.ECCI.PI.Backend.Presentation.Buildings.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Buildings.Responses;

/// <summary>
/// Record representing the response to list the buildings
/// </summary>
internal record GetBuildingListResponse
{
    /// <summary>
    /// Dtos representing the buildings
    /// </summary>
    public required IEnumerable<BuildingDto> Buildings { get; init; }
}
