using System.Collections.Generic;

namespace UCR.ECCI.PI.frontend.Unity.Domain
{
    public interface ILearningSpaceRepository
    {
        public Learning_Space GetLearningSpace(string name);
    }
}
