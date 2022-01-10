using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Interfaces.ExternalApis;
using GitNode.Domain.Models.Platforms;
using GitNode.Infrastructure.ApiClient;
using GitNode.Infrastructure.ExternalApis.GitLab.Repos.Requests;
using GitNode.Infrastructure.ExternalApis.GitLab.Repos.Responses;
using GitNode.Infrastructure.ExternalApis.Interfaces;

namespace GitNode.Infrastructure.ExternalApis.GitLab.Repos
{
    internal class GitLabReposApi : IRepoApi
    {
        private readonly IGenericApi _api;
        private readonly IGitLabMapper _mapper;

        public GitLabReposApi(IGenericApi api, IGitLabMapper mapper)
        {
            _api = api;
            _mapper = mapper;
        }

        public async Task<Repo> CreateRepoAsync(
            string name,
            string description,
            bool @private,
            string token,
            CancellationToken cancellationToken)
        {
            const string uri = "projects";
            var visibility = GetVisibilityValue(@private);
            var request = new CreateRepoGitLabRequestDto(name, description, visibility);
            var response = await _api.PostAuthorizedAsync<GitLabRepoResponseDto, CreateRepoGitLabRequestDto>(
                uri, token, request, cancellationToken);
            return _mapper.Map(response);
        }

        public async Task<IEnumerable<Repo>> GetReposAsync(
            string accountId,
            string token,
            CancellationToken cancellationToken)
        {
            var uri = $"users/{accountId}/projects";
            var response = await _api.GetAuthorizedAsync<IEnumerable<GitLabRepoResponseDto>>(
                uri, token, cancellationToken);
            return response.Select(_mapper.Map);
        }

        public async Task<Repo> UpdateRepoAsync(
            int id,
            string path,
            string owner,
            string name,
            string description,
            bool @private,
            string token,
            CancellationToken cancellationToken)
        {
            var uri = $"projects/{id}";
            var visibility = GetVisibilityValue(@private);
            var request = new UpdateRepoGitLabRequestDto(name, description, visibility);
            var response = await _api.PutAuthorizedAsync<GitLabRepoResponseDto, UpdateRepoGitLabRequestDto>(
                uri, token, request, cancellationToken);
            return _mapper.Map(response);
        }
        
        private static string GetVisibilityValue(bool @private) => @private ? "private" : "public";
    }
}
