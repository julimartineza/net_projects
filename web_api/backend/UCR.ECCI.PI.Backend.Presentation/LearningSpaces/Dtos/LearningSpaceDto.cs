namespace UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Dtos;

/// <summary>
/// Dto representing a learning space
/// </summary>
internal record LearningSpaceDto
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required decimal ScaleX { get; init; }
    public required decimal ScaleY { get; init; }
    public required decimal ScaleZ { get; init; }
    public required string TypeLS { get; init; }
    public required int Floor { get; init; }
    public required string BuildingId { get; init; }
}
