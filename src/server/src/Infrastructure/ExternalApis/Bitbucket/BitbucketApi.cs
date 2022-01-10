using System.Net.Http;
using System.Net.Http.Headers;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Interfaces.ExternalApis;
using GitNode.Infrastructure.ExternalApis.Bitbucket.Auth;
using GitNode.Infrastructure.ExternalApis.Bitbucket.Repos;
using GitNode.Infrastructure.ExternalApis.Bitbucket.Users;
using GitNode.Infrastructure.ExternalApis.Interfaces;
using GitNode.Infrastructure.Options;

namespace GitNode.Infrastructure.ExternalApis.Bitbucket
{
    internal sealed class BitbucketApi : ApiBase, IPlatformApi
    {
        public BitbucketApi(BitbucketOptions options, IBitbucketMapper mapper)
        {
            var httpClient = CreateHttpClient();
            Auth = new BitbucketAuthApi(httpClient, mapper, options);
            Users = new BitbucketUserApi(httpClient, mapper);
            Repos = new BitbucketReposApi(httpClient, mapper);
        }

        public IAuthApi Auth { get; }
        
        public IUserApi Users { get; }

        public IRepoApi Repos { get; }
        
        protected override HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}
