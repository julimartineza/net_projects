using UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Requests;

/// <summary>
/// Request to set a learning space
/// </summary>
internal record SetLearningSpaceRequest
{
    /// <summary>
    /// Dto representing a learning space
    /// </summary>
    public required LearningSpaceDto LearningSpaceDto { get; init; }
}
