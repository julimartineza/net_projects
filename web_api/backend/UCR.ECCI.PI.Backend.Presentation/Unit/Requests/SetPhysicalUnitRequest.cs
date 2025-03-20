using UCR.ECCI.PI.Backend.Presentation.Unit.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Unit.Requests;

/// <summary>
/// Request to set a physical unit
/// </summary>
internal record SetPhysicalUnitRequest
{
    /// <summary>
    /// Dto representing a physical unit
    /// </summary>
    public required PhysicalUnitDto PhysicalUnitDto { get; init; }
}
