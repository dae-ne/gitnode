using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Enums;
using GitNode.Domain.Models.Identity;

namespace GitNode.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<AuthData> GetTokenAsync(
            GrantType grantType,
            string code,
            string refreshToken,
            CancellationToken cancellationToken);

        Task RevokeTokenAsync(string token, CancellationToken cancellationToken);
    }
}