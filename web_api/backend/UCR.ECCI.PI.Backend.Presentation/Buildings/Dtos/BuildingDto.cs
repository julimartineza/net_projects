namespace UCR.ECCI.PI.Backend.Presentation.Buildings.Dtos;

/// <summary>
/// Dto representing a building
/// </summary>
internal record BuildingDto
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Acronym { get; init; }
    public required string Description { get; init; }
    public required string PhysicalUnitName { get; init; }
    public required string Color { get; init; }
    public decimal LocationX { get; init; }
    public decimal LocationY { get; init; }
    public decimal LocationZ { get; init; }
    public decimal ScaleX { get; init; }
    public decimal ScaleY { get; init; }
    public decimal ScaleZ { get; init; }
    public decimal RotationW { get; init; }
    public decimal RotationX { get; init; }
    public decimal RotationY { get; init; }
    public decimal RotationZ { get; init; }
    public required string TypeBuilding { get; init; }
    public bool Status { get; init; }
    public int Floors { get; init; }
}