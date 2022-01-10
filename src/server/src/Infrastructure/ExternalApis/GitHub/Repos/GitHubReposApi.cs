using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Interfaces.ExternalApis;
using GitNode.Domain.Models.Platforms;
using GitNode.Infrastructure.ApiClient;
using GitNode.Infrastructure.ExternalApis.GitHub.Repos.Requests;
using GitNode.Infrastructure.ExternalApis.GitHub.Repos.Responses;
using GitNode.Infrastructure.ExternalApis.Interfaces;

namespace GitNode.Infrastructure.ExternalApis.GitHub.Repos
{
    internal class GitHubReposApi : IRepoApi
    {
        private readonly IGenericApi _api;
        private readonly IGitHubMapper _mapper;

        public GitHubReposApi(IGenericApi api, IGitHubMapper mapper)
        {
            _api = api;
            _mapper = mapper;
        }

        // public async Task<Repo> GetRepoAsync(string reponame, string account, CancellationToken cancellationToken)
        // {
        //     var uri = $"repos/{account}/{reponame}";
        //     var response = await _api.GetAsync<GitHubRepoResponseDto>(uri, cancellationToken);
        //     return _mapper.Map(response);
        // }

        public async Task<Repo> CreateRepoAsync(
            string name,
            string description,
            bool @private,
            string token,
            CancellationToken cancellationToken)
        {
            const string uri = "user/repos";
            var request = new CreateRepoGitHubRequestDto(name, description, @private);
            var response = await _api.PostAuthorizedAsync<GitHubRepoResponseDto, CreateRepoGitHubRequestDto>(
                uri, token, request, cancellationToken);
            return _mapper.Map(response);
        }

        public async Task<IEnumerable<Repo>> GetReposAsync(
            string accountId,
            string token,
            CancellationToken cancellationToken)
        {
            const string uri = "user/repos";
            var response = await _api.GetAuthorizedAsync<IEnumerable<GitHubRepoResponseDto>>(
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
            var uri = $"repos/{owner}/{path}";
            var request = new UpdateRepoGitHubRequestDto(name, description, @private);
            var response = await _api.PatchAuthorizedAsync<GitHubRepoResponseDto, UpdateRepoGitHubRequestDto>(
                uri, token, request, cancellationToken);
            return _mapper.Map(response);
        }
    }
}
