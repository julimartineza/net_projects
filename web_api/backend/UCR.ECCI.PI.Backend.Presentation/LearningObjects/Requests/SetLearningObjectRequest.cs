using UCR.ECCI.PI.Backend.Presentation.LearningObjects.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.LearningObjects.Requests;

/// <summary>
/// Request to set a learning object
/// </summary>
internal record SetLearningObjectRequest
{
    /// <summary>
    /// Dto representing a learning object
    /// </summary>
    public required LearningObjectDto LearningObjectDto { get; init; }
}
