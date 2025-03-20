using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Repositories;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;

namespace UCR.ECCI.PI.Backend.Application.LearningSpacesServices.Implementations
{
    /// <summary>
    /// Service that manages the learning spaces.
    /// </summary>
    internal class LearningSpaceService : ILearningSpaceService
    {
        private readonly ILearningSpaceRepository _LearningSpacesEntityRepository;

        public LearningSpaceService(ILearningSpaceRepository LearningSpacesServiceRepository)
        {
            _LearningSpacesEntityRepository = LearningSpacesServiceRepository;
        }

        /// <summary>
        /// List learning spaces in a building.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<LearningSpace>> ListLearningSpacesAsync(string id)
        {
            return await _LearningSpacesEntityRepository.ListLearningSpacesAsync(id);
        }

        /// <summary>
        /// Set a learning space in the system.
        /// </summary>
        /// <param name="newLearningSpace"></param>
        /// <returns></returns>
        public async Task<int> SetLearningSpaceAsync(LearningSpace newLearningSpace)
        {
            return await _LearningSpacesEntityRepository.SetLearningSpaceAsync(newLearningSpace);
        }
    }
}
