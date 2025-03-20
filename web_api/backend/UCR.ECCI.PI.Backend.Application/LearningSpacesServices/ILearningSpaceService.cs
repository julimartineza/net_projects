using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Entities;

namespace UCR.ECCI.PI.Backend.Application.LearningSpacesServices;

/// <summary>
/// Interface for the learning space service.
/// </summary>
public interface ILearningSpaceService
{
    /// <summary>
    /// List learning spaces in a building.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<IEnumerable<LearningSpace>> ListLearningSpacesAsync(string id);

    /// <summary>
    /// Set a learning space in the system.
    /// </summary>
    /// <param name="newLearningSpace"></param>
    /// <returns></returns>
    public Task<int> SetLearningSpaceAsync(LearningSpace newLearningSpace);
}
