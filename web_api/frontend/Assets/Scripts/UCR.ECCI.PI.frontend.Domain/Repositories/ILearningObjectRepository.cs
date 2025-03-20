using System.Collections.Generic;
using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Domain
{
    public interface ILearningObjectRepository
    {
        public List<Learning_Object> GetLearningObject(string nameLS);
    }
}
