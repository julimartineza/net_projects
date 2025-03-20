using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningObjects.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Entities;

namespace UCR.ECCI.PI.Backend.Domain.LearningObjects.Repositories;

public interface ILearningObjectRepository
{

    /// <summary>
    /// List all learning objects.
    /// </summary>
    /// <returns>Learning Objects</returns>
    public Task<IEnumerable<LearningObject>> ListLearningObjectsAsync();

    /// <summary>
    /// Set a learning object.
    /// </summary>
    /// <param name="learningObject"></param>
    /// <returns></returns>
    public Task<int> SetLearningObjectAsync(LearningObject learningObject);

    /// <summary>
    /// Get the learging object by learning space id
    /// </summary>
    /// <param name="idLS"></param>
    /// <returns></returns>
    public Task<IEnumerable<LearningObject>> GetLearningObjectsAsync(string idLS);

    /// <summary>
    /// Edits a Learning Object
    /// </summary>
    /// <param LearningObject="learningObject"></param>
    /// <returns>  0 when edited succesfully </returns>
    public Task<int> EditLearningObjectAsync(LearningObject learningObject);
}