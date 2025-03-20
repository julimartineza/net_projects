namespace UCR.ECCI.PI.Backend.Presentation.Unit.Dtos;

/// <summary>
/// Dto representing an administrative unit
/// </summary>
internal class AdministrativeUnitDto
{
    public required string Name { get; init; }
    public required string AdministrativeUnitType { get; init;  }
    public required string SupervisedBy { get; init; }
    public required string BuildingId { get; init; }
    public required bool Status { get; set; }
}
