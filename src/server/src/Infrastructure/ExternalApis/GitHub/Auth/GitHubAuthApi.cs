using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Interfaces.ExternalApis;
using GitNode.Domain.Models.Platforms;
using GitNode.Infrastructure.ApiClient;
using GitNode.Infrastructure.ExternalApis.GitHub.Auth.Requests;
using GitNode.Infrastructure.ExternalApis.GitHub.Auth.Responses;
using GitNode.Infrastructure.ExternalApis.Interfaces;
using GitNode.Infrastructure.Options;

namespace GitNode.Infrastructure.ExternalApis.GitHub.Auth
{
    internal class GitHubAuthApi : IAuthApi
    {
        private readonly IGenericApi _api;
        private readonly IGitHubMapper _mapper;
        private readonly GitHubOptions _options;

        public GitHubAuthApi(IGenericApi api, IGitHubMapper mapper, GitHubOptions options)
        {
            _api = api;
            _mapper = mapper;
            _options = options;
        }

        public async Task<Token> GetTokenAsync(string code, CancellationToken cancellationToken)
        {
            const string uri = "https://github.com/login/oauth/access_token";
            var request = new GetTokenGitHubRequestDto(code, _options.ClientSecret, _options.ClientId);
            var response = await _api.PostAsync<GitHubTokenResponseDto, GetTokenGitHubRequestDto>(
                uri, request, cancellationToken);
            return _mapper.Map(response);
        }
    }
}
