using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Entities;

namespace GitNode.Domain.Interfaces.Repositories
{
    public interface IAccountRepository : IGenericRepository<AccountEntity, int>
    {
        Task<AccountEntity> GetWithPlatformAsync(int accountId, string userId, CancellationToken cancellationToken);
        
        Task<AccountEntity> GetWithPlatformAsync(string username, string userId, CancellationToken cancellationToken);
        
        Task<IEnumerable<AccountEntity>> GetListWithPlatformsAsync(string userId, CancellationToken cancellationToken);
    }
}