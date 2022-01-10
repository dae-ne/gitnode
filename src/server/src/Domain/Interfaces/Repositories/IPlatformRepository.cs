using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Entities;

namespace GitNode.Domain.Interfaces.Repositories
{
    public interface IPlatformRepository : IGenericRepository<PlatformEntity, int>
    {
        Task<PlatformEntity> GetByNameAsync(string platformName, CancellationToken cancellationToken);
    }
}