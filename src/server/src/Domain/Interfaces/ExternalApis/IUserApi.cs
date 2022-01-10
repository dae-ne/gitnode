using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Models.Platforms;

namespace GitNode.Domain.Interfaces.ExternalApis
{
    public interface IUserApi
    {
        Task<User> GetAuthenticatedUserAsync(string token, CancellationToken cancellationToken);

        Task<User> GetUserAsync(string username, CancellationToken cancellationToken);
    }
}
