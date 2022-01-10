using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Interfaces.ExternalApis;
using GitNode.Domain.Models.Platforms;
using GitNode.Infrastructure.ExternalApis.Interfaces;

namespace GitNode.Infrastructure.ExternalApis.Bitbucket.Repos
{
    internal class BitbucketReposApi : IRepoApi
    {
        private readonly HttpClient _client;
        private readonly IBitbucketMapper _mapper;

        public BitbucketReposApi(HttpClient client, IBitbucketMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public Task<Repo> CreateRepoAsync(
            string name,
            string description,
            bool @private,
            string token,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException(); // TODO: implement
        }

        public Task<IEnumerable<Repo>> GetReposAsync(
            string accountId,
            string token,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Repo> UpdateRepoAsync(int id, string path, string owner, string name, string description, bool @private, string token,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
