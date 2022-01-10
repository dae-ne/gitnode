using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Entities;
using GitNode.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GitNode.Persistence.Repositories
{
    internal class AccountRepository : GenericRepository<AccountEntity, AppDbContext, int>, IAccountRepository
    {
        public AccountRepository(AppDbContext db) : base(db) { }

        public Task<AccountEntity> GetWithPlatformAsync(
            int accountId,
            string userId,
            CancellationToken cancellationToken)
        {
            return Db.Accounts
                .Where(a => a.Id == accountId && a.UserId == userId)
                .Include(a => a.Platform)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public Task<AccountEntity> GetWithPlatformAsync(
            string username,
            string userId,
            CancellationToken cancellationToken)
        {
            return Db.Accounts
                .Where(a => a.Login == username && a.UserId == userId)
                .Include(a => a.Platform)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<AccountEntity>> GetListWithPlatformsAsync(
            string userId,
            CancellationToken cancellationToken)
        {
            return await Db.Accounts
                .Where(a => a.UserId == userId)
                .Include(a => a.Platform)
                .ToListAsync(cancellationToken);
        }
    }
}