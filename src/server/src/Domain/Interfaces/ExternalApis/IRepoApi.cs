using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Models.Platforms;

namespace GitNode.Domain.Interfaces.ExternalApis
{
    public interface IRepoApi
    {
        Task<Repo> CreateRepoAsync(
            string name,
            string description,
            bool @private,
            string token,
            CancellationToken cancellationToken);
        
        Task<IEnumerable<Repo>> GetReposAsync(
            string accountId,
            string token,
            CancellationToken cancellationToken);

        Task<Repo> UpdateRepoAsync(
            int id,
            string path,
            string owner,
            string name,
            string description,
            bool @private,
            string token,
            CancellationToken cancellationToken);
    }
}
