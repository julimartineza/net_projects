using UCR.ECCI.PI.Backend.Presentation.Trees.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Trees.Requests;

internal record SetTreeRequest
{
    public required TreeDto tree {  get; init; }
}
