namespace UCR.ECCI.PI.Backend.Presentation.Trees.Dtos;

internal record TreeDto
{
    public int Id { get; init; }
    public double LocationX { get; init; }
    public double LocationY { get; init; }
    public double LocationZ { get; init; }
    public double Scale { get; init; }
}
