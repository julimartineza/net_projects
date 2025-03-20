using UCR.ECCI.PI.Backend.Presentation.Unit.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Unit.Requests;

/// <summary>
/// Request to set an administrative unit
/// </summary>
internal record SetAdministrativeUnitRequest
{
    /// <summary>
    /// Dto representing an administrative unit
    /// </summary>
    public required AdministrativeUnitDto AdministrativeUnitDto { get; init; }
}
