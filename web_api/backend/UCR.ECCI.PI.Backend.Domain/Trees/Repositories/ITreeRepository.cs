using UCR.ECCI.PI.Backend.Domain.Trees.Entities;

namespace UCR.ECCI.PI.Backend.Domain.Trees.Repositories;

public interface ITreeRepository
{
    public Task<int> SetTree(Tree tree);
    public Task<IEnumerable<Tree>> GetTrees();
}
