using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.Trees.Entities;
using UCR.ECCI.PI.Backend.Domain.Trees.Repositories;

namespace UCR.ECCI.PI.Backend.Infrastructure.EntityTree.Repositories;

internal class TreeRepository : ITreeRepository
{
    private DatabaseContext _databaseContext { get; set; }

    /// <summary>
    /// Building repository constructor.
    /// </summary>
    /// <param name="databaseContext"></param>
    public TreeRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<int> SetTree(Tree tree)
    {
        _databaseContext.Tree.Add(tree);
        await _databaseContext.SaveChangesAsync();
        return 0;
    }

    public async Task<IEnumerable<Tree>> GetTrees()
    {
        var trees = await _databaseContext.Tree.ToListAsync();

        return trees.AsEnumerable();
    }
}
