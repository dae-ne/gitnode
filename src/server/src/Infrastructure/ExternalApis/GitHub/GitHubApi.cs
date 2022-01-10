using System;
using System.Net.Http;
using System.Net.Http.Headers;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Interfaces.ExternalApis;
using GitNode.Infrastructure.ApiClient;
using GitNode.Infrastructure.ExternalApis.GitHub.Auth;
using GitNode.Infrastructure.ExternalApis.GitHub.Repos;
using GitNode.Infrastructure.ExternalApis.GitHub.Users;
using GitNode.Infrastructure.ExternalApis.Interfaces;
using GitNode.Infrastructure.Options;

namespace GitNode.Infrastructure.ExternalApis.GitHub
{
    internal sealed class GitHubApi : ApiBase, IPlatformApi
    {
        public GitHubApi(HttpClient defaultHttpClient, GitHubOptions options, IGitHubMapper mapper)
        {
            const string authorization = "Token";
            var httpClient = CreateHttpClient();
            var api = new GenericApi(authorization, httpClient);
            var authApi = new GenericApi(authorization, defaultHttpClient);
            Auth = new GitHubAuthApi(authApi, mapper, options);
            Users = new GitHubUsersApi(api, mapper);
            Repos = new GitHubReposApi(api, mapper);
        }

        public IAuthApi Auth { get; }
        
        public IUserApi Users { get; }

        public IRepoApi Repos { get; }

        protected override HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.BaseAddress = new Uri("https://api.github.com/");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("GitNode");
            return httpClient;
        }
    }
}
