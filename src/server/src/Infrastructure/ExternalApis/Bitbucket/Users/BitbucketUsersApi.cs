using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Interfaces.ExternalApis;
using GitNode.Domain.Models.Platforms;
using GitNode.Infrastructure.ExternalApis.Interfaces;

namespace GitNode.Infrastructure.ExternalApis.Bitbucket.Users
{
    internal class BitbucketUserApi : IUserApi
    {
        private readonly HttpClient _client;
        private readonly IBitbucketMapper _mapper;

        public BitbucketUserApi(HttpClient client, IBitbucketMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public Task<User> GetAuthenticatedUserAsync(string token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(); // TODO: implement

            // using var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.bitbucket.org/2.0/user");
            // requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // var response = await _client.ApiClient.SendAsync(requestMessage);
            //
            // var x = await response.Content.ReadAsStringAsync();
            //
            // if (response.IsSuccessStatusCode)
            // {
            //     var model = await response.Content.ReadAsAsync<BitbucketUser>();
            //     return _mapper.Map(model);
            // }
            // else
            // {
            //     throw new ExternalApiException(response.ReasonPhrase);
            // }
        }

        public Task<User> GetUserAsync(string username, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(); // TODO: implement

            // using var response = await _client.ApiClient.GetAsync($"https://api.bitbucket.org/2.0/user");
            //
            // if (response.IsSuccessStatusCode)
            // {
            //     var model = await response.Content.ReadAsAsync<BitbucketUser>();
            //     return _mapper.Map(model);
            // }
            // else
            // {
            //     throw new ExternalApiException(response.StatusCode.ToString());
            // }
        }
    }
}
