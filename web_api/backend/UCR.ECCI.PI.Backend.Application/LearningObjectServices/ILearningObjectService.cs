using UCR.ECCI.PI.Backend.Domain.LearningObjects.Entities;

namespace UCR.ECCI.PI.Backend.Application.LearningObjectServices;

public interface ILearningObjectService
{
    /// <summary>
    /// List all learning objects
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<LearningObject>> ListLearningObjectsAsync();

    /// <summary>
    /// Set a learning object in the system.
    /// </summary>
    /// <param name="learningObject"></param>
    /// <returns></returns>
    public Task<int> SetLearningObjectAsync(LearningObject learningObject);

    /// <summary>
    /// Get the laerning object by learning space id.
    /// </summary>
    /// <param name="idLS"></param>
    /// <returns></returns>
    public Task<IEnumerable<LearningObject>> GetLearningObjectsAsync(string idLS);


    /// <summary>
    /// Set a learning object in the system.
    /// </summary>
    /// <param name="learningObject"></param>
    /// <returns></returns>
    public Task<int> EditLearningObjectAsync(LearningObject learningObject);
}
