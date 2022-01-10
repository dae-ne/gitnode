using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Interfaces.ExternalApis;
using GitNode.Domain.Models.Platforms;
using GitNode.Infrastructure.ApiClient;
using GitNode.Infrastructure.ExternalApis.GitHub.Users.Responses;
using GitNode.Infrastructure.ExternalApis.Interfaces;

namespace GitNode.Infrastructure.ExternalApis.GitHub.Users
{
    internal class GitHubUsersApi : IUserApi
    {
        private readonly IGenericApi _api;
        private readonly IGitHubMapper _mapper;

        public GitHubUsersApi(IGenericApi api, IGitHubMapper mapper)
        {
            _api = api;
            _mapper = mapper;
        }

        public async Task<User> GetAuthenticatedUserAsync(string token, CancellationToken cancellationToken)
        {
            const string uri = "user";
            var response = await _api.GetAuthorizedAsync<GitHubUserResponseDto>(uri, token, cancellationToken);
            return _mapper.Map(response);
        }

        public async Task<User> GetUserAsync(string username, CancellationToken cancellationToken)
        {
            var uri = $"users/{username}";
            var response = await _api.GetAsync<GitHubUserResponseDto>(uri, cancellationToken);
            return _mapper.Map(response);
        }
    }
}
