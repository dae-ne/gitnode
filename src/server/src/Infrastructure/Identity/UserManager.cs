using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Exceptions;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Enums;
using GitNode.Domain.Models.Identity;
using GitNode.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace GitNode.Infrastructure.Identity
{
    internal class UserManager : IUserManager
    {
        private readonly ApiClient.GenericApi _genericApi;
        private readonly IGoogleConfigurationService _configurationService;
        private readonly IOptions<IdentityOptions> _options;

        public UserManager(
            IGoogleConfigurationService configurationService,
            IHttpClientFactory httpClientFactory,
            IOptions<IdentityOptions> options)
        {
            var httpClient = httpClientFactory.CreateClient();
            _genericApi = new ApiClient.GenericApi("Bearer", httpClient);
            _configurationService = configurationService;
            _options = options;
        }

        public async Task<AuthData> GetTokenAsync(
            GrantType grantType,
            string code,
            string refreshToken, 
            CancellationToken cancellationToken)
        {
            var request = TokenRequest.Create(_options.Value, grantType, code, refreshToken);
            var configuration = await _configurationService.GetAsync();
            var response = await _genericApi.PostAsync<TokenData, TokenRequest>(
                configuration.TokenEndpoint, request, cancellationToken);
            var user = DecodeJwt(response.IdToken);
            return new AuthData(response, user);
        }

        public async Task RevokeTokenAsync(string token, CancellationToken cancellationToken)
        {
            var configuration = await _configurationService.GetAsync();
            
            if (!configuration.AdditionalData.TryGetValue("revocation_endpoint", out var value))
            {
                // TODO: exception type
                throw new Exception();
            }
            
            var uri = $"{(string) value}?token={token}";
            var response = await _genericApi.HttpClient.PostAsync(uri, null!, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new ExternalApiException((int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static UserData DecodeJwt(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            return new UserData
            {
                Id = GetClaimValue(token, "sub"),
                Email = GetClaimValue(token, "email"),
                GivenName = GetClaimValue(token, "given_name"),
                Surname = GetClaimValue(token, "family_name"),
                Picture = GetClaimValue(token, "picture")
            };
        }

        private static string GetClaimValue(JwtSecurityToken token, string claimType) =>
            token.Claims
                .Where(c => c.Type == claimType)
                .Select(c => c.Value)
                .FirstOrDefault();
    }
}