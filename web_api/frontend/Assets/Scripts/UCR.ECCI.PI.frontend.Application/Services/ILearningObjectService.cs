using System.Collections.Generic;
using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Application.Services
{
    public interface ILearningObjectService
    {
        public List<Learning_Object> GetLearningObject(string nameLS);
    }
}
