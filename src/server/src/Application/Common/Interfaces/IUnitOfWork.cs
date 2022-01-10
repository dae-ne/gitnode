using System;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Interfaces.Repositories;

namespace GitNode.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        
        IAccountRepository Accounts { get; }
        
        IPlatformRepository Platforms { get; }
        
        IRepoRepository Repos { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}