using UCR.ECCI.PI.Backend.Presentation.LearningObjects.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.LearningObjects.Responses;

/// <summary>
/// Response to list learning objects
/// </summary>
internal record ListLearningObjectsResponse
{
    /// <summary>
    /// Learning objects list
    /// </summary>
    public required IEnumerable<LearningObjectDto> LearningObjects { get; init; }
}
