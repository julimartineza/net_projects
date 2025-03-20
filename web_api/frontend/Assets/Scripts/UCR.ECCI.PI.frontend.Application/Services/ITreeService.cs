using System.Collections.Generic;
using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Application.Services
{
    public interface ITreeService
    {
        public List<Tree> GetTrees();
    }
}
