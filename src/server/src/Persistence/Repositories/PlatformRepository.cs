using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Entities;
using GitNode.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GitNode.Persistence.Repositories
{
    internal class PlatformRepository : GenericRepository<PlatformEntity, AppDbContext, int>, IPlatformRepository
    {
        public PlatformRepository(AppDbContext db) : base(db) { }

        public Task<PlatformEntity> GetByNameAsync(string platformName, CancellationToken cancellationToken)
        {
            return Db.Platforms
                .Where(p => p.Name.ToLower() == platformName.ToLower())
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}