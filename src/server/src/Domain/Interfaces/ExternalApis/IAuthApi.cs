using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Models.Platforms;

namespace GitNode.Domain.Interfaces.ExternalApis
{
    public interface IAuthApi
    {
        Task<Token> GetTokenAsync(string code, CancellationToken cancellationToken);
    }
}