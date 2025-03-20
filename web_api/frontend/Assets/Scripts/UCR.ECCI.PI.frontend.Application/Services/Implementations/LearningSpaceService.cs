using System.Collections.Generic;
using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Application.Services
{
    internal class LearningSpaceService : ILearningSpaceService
    {
        private readonly ILearningSpaceRepository _learningspaceRepository;

        public LearningSpaceService(ILearningSpaceRepository learningspaceRepository)
        {
            _learningspaceRepository = learningspaceRepository;
        }

        public Learning_Space GetLearningSpace(string name)
        {
            return _learningspaceRepository.GetLearningSpace(name);
        }
    }
}