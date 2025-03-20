using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Repositories;
using UCR.ECCI.PI.Backend.Domain.Trees.Entities;
using UCR.ECCI.PI.Backend.Domain.Trees.Repositories;

namespace UCR.ECCI.PI.Backend.Application.TreeServices.Implementations;

internal class TreeService : ITreeService
{

    private readonly ITreeRepository _treeRepository;

    public TreeService(ITreeRepository TreeService)
    {
        _treeRepository = TreeService;
    }

    public async Task<int> SetTree(Tree tree)
    {
        return await _treeRepository.SetTree(tree);
    }

    public Task<IEnumerable<Tree>> GetTrees()
    {
        return _treeRepository.GetTrees();
    }
}
