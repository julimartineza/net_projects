using UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Responses;

/// <summary>
/// Response to list learning spaces
/// </summary>
internal record ListLearningSpacesResponse
{
    /// <summary>
    /// Learning spaces list
    /// </summary>
    public required IEnumerable<LearningSpaceDto> LearningSpaces { get; init; }
}
