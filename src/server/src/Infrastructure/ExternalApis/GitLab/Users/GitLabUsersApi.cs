using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Interfaces.ExternalApis;
using GitNode.Domain.Models.Platforms;
using GitNode.Infrastructure.ApiClient;
using GitNode.Infrastructure.ExternalApis.GitLab.Users.Responses;
using GitNode.Infrastructure.ExternalApis.Interfaces;

namespace GitNode.Infrastructure.ExternalApis.GitLab.Users
{
    internal class GitLabUsersApi : IUserApi
    {
        private readonly IGenericApi _api;
        private readonly IGitLabMapper _mapper;

        public GitLabUsersApi(IGenericApi api, IGitLabMapper mapper)
        {
            _api = api;
            _mapper = mapper;
        }

        public async Task<User> GetAuthenticatedUserAsync(string token, CancellationToken cancellationToken)
        {
            const string uri = "user";
            var response = await _api.GetAuthorizedAsync<GitLabUserResponseDto>(uri, token, cancellationToken);
            return _mapper.Map(response);
        }

        public async Task<User> GetUserAsync(string username, CancellationToken cancellationToken)
        {
            var uri = $"users?username={username}";
            var response = await _api.GetAsync<GitLabUserResponseDto>(uri, cancellationToken);
            return _mapper.Map(response);
        }
    }
}
