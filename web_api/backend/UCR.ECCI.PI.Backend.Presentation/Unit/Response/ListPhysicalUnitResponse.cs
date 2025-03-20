using UCR.ECCI.PI.Backend.Presentation.Unit.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Unit.Response;

/// <summary>
/// Response to list physical units
/// </summary>
internal record ListPhysicalUnitResponse
{
    /// <summary>
    /// Physical units list
    /// </summary>
    public required IEnumerable<PhysicalUnitDto> PhysicalUnits { get; init; }
}
