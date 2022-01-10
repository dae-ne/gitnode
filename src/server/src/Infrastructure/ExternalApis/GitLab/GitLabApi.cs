using System;
using System.Net.Http;
using System.Net.Http.Headers;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Interfaces.ExternalApis;
using GitNode.Infrastructure.ApiClient;
using GitNode.Infrastructure.ExternalApis.GitLab.Auth;
using GitNode.Infrastructure.ExternalApis.GitLab.Repos;
using GitNode.Infrastructure.ExternalApis.GitLab.Users;
using GitNode.Infrastructure.ExternalApis.Interfaces;
using GitNode.Infrastructure.Options;

namespace GitNode.Infrastructure.ExternalApis.GitLab
{
    internal sealed class GitLabApi : ApiBase, IPlatformApi
    {
        public GitLabApi(HttpClient defaultHttpClient, GitLabOptions options, IGitLabMapper mapper)
        {
            const string authorization = "Bearer";
            var httpClient = CreateHttpClient();
            var api = new GenericApi(authorization, httpClient);
            var authApi = new GenericApi(authorization, defaultHttpClient);
            Auth = new GitLabAuthApi(authApi, mapper, options);
            Users = new GitLabUsersApi(api, mapper);
            Repos = new GitLabReposApi(api, mapper);
        }

        public IAuthApi Auth { get; }
        
        public IUserApi Users { get; }

        public IRepoApi Repos { get; }
        
        protected override HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.BaseAddress = new Uri("https://gitlab.com/api/v4/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}
