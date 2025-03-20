using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Entities;

namespace UCR.ECCI.PI.Backend.Domain.LearningSpaces.Repositories;

public interface ILearningSpaceRepository
{

    /// <summary>
    /// List all learning spaces.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<IEnumerable<LearningSpace>> ListLearningSpacesAsync(string id);

    /// <summary>
    /// Get a learning space by its id.
    /// </summary>
    /// <param name="learningSpace"></param>
    /// <returns></returns>
    public Task<int> SetLearningSpaceAsync(LearningSpace learningSpace);
}