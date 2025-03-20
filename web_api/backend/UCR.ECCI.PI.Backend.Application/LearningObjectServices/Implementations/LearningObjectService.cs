using UCR.ECCI.PI.Backend.Domain.LearningObjects.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningObjects.Repositories;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Repositories;

namespace UCR.ECCI.PI.Backend.Application.LearningObjectServices.Implementations;

internal class LearningObjectService : ILearningObjectService
{ 
        private readonly ILearningObjectRepository _LearningObjectEntityRepository;

    public LearningObjectService(ILearningObjectRepository LearningObjectServiceRepository)
    {
            _LearningObjectEntityRepository = LearningObjectServiceRepository;
    }

    /// <summary>
    /// List learning objects
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<LearningObject>> ListLearningObjectsAsync()
    {
        return await _LearningObjectEntityRepository.ListLearningObjectsAsync();
    }

    /// <summary>
    /// Set a learning object in the system.
    /// </summary>
    /// <param name="learningObject"></param>
    /// <returns></returns>
    public async Task<int> SetLearningObjectAsync(LearningObject learningObject)
    {
        return await _LearningObjectEntityRepository.SetLearningObjectAsync(learningObject);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idLS"></param>
    /// <returns></returns>
    public async Task<IEnumerable<LearningObject>> GetLearningObjectsAsync(string idLS)
    {
        return await _LearningObjectEntityRepository.GetLearningObjectsAsync(idLS);
    }

    public async Task<int> EditLearningObjectAsync(LearningObject learningObject)
    {
        return await _LearningObjectEntityRepository.EditLearningObjectAsync(learningObject);
    }
}