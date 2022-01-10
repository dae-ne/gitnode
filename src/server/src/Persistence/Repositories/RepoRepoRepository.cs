using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Entities;
using GitNode.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GitNode.Persistence.Repositories
{
    internal class RepoRepoRepository : GenericRepository<RepoEntity, AppDbContext, int>, IRepoRepository
    {
        public RepoRepoRepository(AppDbContext db) : base(db) { }

        public Task<RepoEntity> GetWithAccountAsync(int id, string userId, CancellationToken cancellationToken)
        {
            return Db.Repos
                .Where(r => r.Id == id && r.Account.UserId == userId)
                .Include(r => r.Account)
                .FirstOrDefaultAsync(cancellationToken);
        }
        
        public async Task<IEnumerable<RepoEntity>> GetListWithAccountAsync(string userId, CancellationToken cancellationToken)
        {
            return await Db.Repos
                .Where(r => r.Account.UserId == userId)
                .Include(r => r.Account)
                .ToListAsync(cancellationToken);
        }
    }
}