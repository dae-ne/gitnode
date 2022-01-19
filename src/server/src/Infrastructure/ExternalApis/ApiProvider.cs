using System.Net.Http;
using System.Net.Http.Headers;
using GitNode.Application.Common.Interfaces;
using GitNode.Infrastructure.ExternalApis.Bitbucket;
using GitNode.Infrastructure.ExternalApis.GitHub;
using GitNode.Infrastructure.ExternalApis.GitLab;
using GitNode.Infrastructure.ExternalApis.Interfaces;
using GitNode.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace GitNode.Infrastructure.ExternalApis
{
    internal class ApiProvider : IApiProvider
    {
        public ApiProvider(
            IHttpClientFactory httpClientFactory,
            IOptions<GitHubOptions> gitHubOptions,
            IOptions<BitbucketOptions> bitbucketOptions,
            IOptions<GitLabOptions> gitLabOptions,
            IGitHubMapper gitHubMapper,
            IBitbucketMapper bitbucketMapper,
            IGitLabMapper gitLabMapper)
        {
            var httpClient = httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            GitHub = new GitHubApi(httpClient, gitHubOptions.Value, gitHubMapper);
            Bitbucket = new BitbucketApi(bitbucketOptions.Value, bitbucketMapper);
            GitLab = new GitLabApi(httpClient, gitLabOptions.Value, gitLabMapper);
        }

        public IPlatformApi GitHub { get; }

        public IPlatformApi Bitbucket { get; }

        public IPlatformApi GitLab { get; }
    }
}
