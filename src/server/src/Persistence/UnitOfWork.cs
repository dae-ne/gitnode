using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Interfaces.Repositories;
using GitNode.Persistence.Repositories;

namespace GitNode.Persistence
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        private IUserRepository _users;
        private IAccountRepository _accounts;
        private IPlatformRepository _platforms;
        private IRepoRepository _repos;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
        }

        public IUserRepository Users => _users ??= new UserRepository(_db);

        public IAccountRepository Accounts => _accounts ??= new AccountRepository(_db);

        public IPlatformRepository Platforms => _platforms ??= new PlatformRepository(_db);

        public IRepoRepository Repos => _repos ??= new RepoRepoRepository(_db);

        public int SaveChanges() => _db.SaveChanges();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken) =>
            _db.SaveChangesAsync(cancellationToken);

        public void Dispose() => _db.Dispose();
    }
}