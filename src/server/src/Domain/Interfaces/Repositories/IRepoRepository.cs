using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Entities;

namespace GitNode.Domain.Interfaces.Repositories
{
    public interface IRepoRepository : IGenericRepository<RepoEntity, int>
    {
        Task<RepoEntity> GetWithAccountAsync(int id, string userId, CancellationToken cancellationToken);
        
        Task<IEnumerable<RepoEntity>> GetListWithAccountAsync(string userId, CancellationToken cancellationToken);
    }
}