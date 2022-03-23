using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace GitNode.Infrastructure.Identity
{
    internal class GoogleConfigurationService : IGoogleConfigurationService
    {
        public static readonly TimeSpan DefaultAbsoluteExpiration = TimeSpan.FromDays(1);
        public static readonly TimeSpan DefaultMinimalRefreshInterval = TimeSpan.FromSeconds(30);

        private readonly IConfigurationRetriever<OpenIdConnectConfiguration> _configRetriever =
            new OpenIdConnectConfigurationRetriever();
        
        private readonly IDocumentRetriever _docRetriever = new HttpDocumentRetriever();

        private OpenIdConnectConfiguration _configuration;
        
        private readonly SemaphoreSlim _refreshLock = new(1, 1);
        
        private DateTimeOffset _syncAfter = DateTimeOffset.MinValue;
        private DateTimeOffset _lastRefresh = DateTimeOffset.MinValue;

        public async Task<OpenIdConnectConfiguration> GetAsync()
        {
            var now = DateTimeOffset.UtcNow;

            if (_configuration != null && _syncAfter > now)
            {
                return _configuration;   
            }

            await _refreshLock.WaitAsync();
            
            if (_syncAfter <= now)
            {
                _configuration = await GetNewConfigurationAsync(GoogleDefaults.DiscoveryDocument)
                    .ConfigureAwait(false);   
            }
            if (_configuration == null)
            {
                throw new InvalidOperationException(GoogleDefaults.DiscoveryDocument);
            }
            
            _lastRefresh = now;
            _syncAfter = DateTimeUtil.Add(now.UtcDateTime, DefaultAbsoluteExpiration);
            return _configuration;
        }

        public void Expire()
        {
            var now = DateTimeOffset.UtcNow;
            
            if (now >= DateTimeUtil.Add(_lastRefresh.UtcDateTime, DefaultMinimalRefreshInterval))
            {
                _syncAfter = now;   
            }
        }

        private async Task<OpenIdConnectConfiguration> GetNewConfigurationAsync(string metadataAddress)
        {
            return await _configRetriever
                .GetConfigurationAsync(metadataAddress, _docRetriever, CancellationToken.None)
                .ConfigureAwait(false);
        }
    }
}