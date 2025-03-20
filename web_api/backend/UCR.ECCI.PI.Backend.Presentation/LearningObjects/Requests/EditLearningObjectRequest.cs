using UCR.ECCI.PI.Backend.Presentation.LearningObjects.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.LearningObjects.Requests;

/// <summary>
/// Request to edit a learning object
/// </summary>
internal class EditLearningObjectRequest
{
    /// <summary>
    /// Dto representing a learning object
    /// </summary>
    public required LearningObjectDto LearningObjectDto { get; init; }
}
