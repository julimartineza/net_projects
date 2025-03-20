namespace UCR.ECCI.PI.Backend.Presentation.LearningObjects.Dtos;

/// <summary>
/// Dto representing a learning object
/// </summary>
internal record LearningObjectDto
{
    public required string Id { get; init; }
    public required string TypeLO { get; init; }
    public required decimal LocationX { get; init; }
    public required decimal LocationY { get; init; }
    public required decimal LocationZ { get; init; }
    public required decimal ScaleX { get; init; }
    public required decimal ScaleY { get; init; }
    public required decimal ScaleZ { get; init; }
    public required decimal RotationW { get; init; }
    public required decimal RotationX { get; init; }
    public required decimal RotationY { get; init; }
    public required decimal RotationZ { get; init; }
    public required string LearningSpaceName { get; init; }
}
