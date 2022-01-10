using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Interfaces.ExternalApis;
using GitNode.Domain.Models.Platforms;
using GitNode.Infrastructure.ApiClient;
using GitNode.Infrastructure.ExternalApis.GitLab.Auth.Requests;
using GitNode.Infrastructure.ExternalApis.GitLab.Auth.Responses;
using GitNode.Infrastructure.ExternalApis.Interfaces;
using GitNode.Infrastructure.Options;

namespace GitNode.Infrastructure.ExternalApis.GitLab.Auth
{
    internal class GitLabAuthApi : IAuthApi
    {
        private readonly IGenericApi _api;
        private readonly IGitLabMapper _mapper;
        private readonly GitLabOptions _options;

        public GitLabAuthApi(IGenericApi api, IGitLabMapper mapper, GitLabOptions options)
        {
            _api = api;
            _mapper = mapper;
            _options = options;
        }
        
        public async Task<Token> GetTokenAsync(string code, CancellationToken cancellationToken)
        {
            const string uri = "https://gitlab.com/oauth/token";
            var request = new GetTokenGitLabRequestDto(
                code, _options.Secret, _options.ApplicationId, _options.CallbackUrl);
            var response = await _api.PostAsync<GitLabTokenResponseDto, GetTokenGitLabRequestDto>(
                uri, request, cancellationToken);
            return _mapper.Map(response);
        }
    }
}