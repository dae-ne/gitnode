using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace GitNode.Infrastructure.Identity
{
    internal class ConfigurationManager : IConfigurationManager<OpenIdConnectConfiguration>
    {
        private readonly IGoogleConfigurationService _googleConfigurationService;

        public ConfigurationManager(IGoogleConfigurationService googleConfigurationService)
        {
            _googleConfigurationService = googleConfigurationService;
        }

        public async Task<OpenIdConnectConfiguration> GetConfigurationAsync(CancellationToken cancel) =>
            await _googleConfigurationService.GetAsync();

        public void RequestRefresh() => _googleConfigurationService.Expire();
    }
}