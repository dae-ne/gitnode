using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace GitNode.Infrastructure.Identity
{
    public interface IGoogleConfigurationService
    {
        Task<OpenIdConnectConfiguration> GetAsync();

        void Expire();
    }
}