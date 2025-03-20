using UCR.ECCI.PI.Backend.Domain.Trees.Entities;

namespace UCR.ECCI.PI.Backend.Application.TreeServices;

public interface ITreeService
{
    public Task<int> SetTree(Tree tree);
    public Task<IEnumerable<Tree>> GetTrees();
}
