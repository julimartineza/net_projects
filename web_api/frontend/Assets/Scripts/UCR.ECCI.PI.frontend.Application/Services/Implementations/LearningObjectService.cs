using System.Collections.Generic;
using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Application.Services
{
    internal class LearningObjectService : ILearningObjectService
    {
        private readonly ILearningObjectRepository _learningObjectRepository;

        public LearningObjectService(ILearningObjectRepository learningObjectRepository)
        {
            _learningObjectRepository = learningObjectRepository;
        }

        public List<Learning_Object> GetLearningObject(string nameLS)
        {
            return _learningObjectRepository.GetLearningObject(nameLS);
        }
    }
}
