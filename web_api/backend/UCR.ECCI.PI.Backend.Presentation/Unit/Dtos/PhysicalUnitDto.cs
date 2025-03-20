namespace UCR.ECCI.PI.Backend.Presentation.Unit.Dtos;

/// <summary>
/// Dto representing a physical unit
/// </summary>
internal record PhysicalUnitDto
{
    public required string Name { get; init; }
    public required string PhysicalUnitType { get; init; }
    public required string LocatedIn { get; init; }
    public required bool Status { get; set; }
}
