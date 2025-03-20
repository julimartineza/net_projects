using UCR.ECCI.PI.Backend.Presentation.Trees.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Trees.Responses;

internal record GetTreeResponse
{
    public required IEnumerable<TreeDto> Trees { get; init; }
}
