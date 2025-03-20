using System.Collections.Generic;
using System.Linq;
using UCR.ECCI.PI.frontend.Domain.Value_Objects;
using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Application.Services
{
    internal class TreeService : ITreeService
    {
        private readonly ITreeRepository _treeRepository;


        public TreeService(ITreeRepository treeRepository)
        {
            _treeRepository = treeRepository;
        }

        /// <summary>
        /// Retrieves the list of trees.
        /// </summary>
        /// <returns>The list of trees.</returns>
        public List<Tree> GetTrees()
        {
            return _treeRepository.GetTrees();
        }

    }
}