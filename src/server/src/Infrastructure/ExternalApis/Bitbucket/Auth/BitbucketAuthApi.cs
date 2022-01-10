using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Interfaces.ExternalApis;
using GitNode.Domain.Models.Platforms;
using GitNode.Infrastructure.ExternalApis.Interfaces;
using GitNode.Infrastructure.Options;

namespace GitNode.Infrastructure.ExternalApis.Bitbucket.Auth
{
    internal class BitbucketAuthApi : IAuthApi
    {
        private readonly HttpClient _client;
        private readonly IBitbucketMapper _mapper;
        private readonly BitbucketOptions _options;

        public BitbucketAuthApi(HttpClient client, IBitbucketMapper mapper, BitbucketOptions options)
        {
            _client = client;
            _mapper = mapper;
            _options = options;
        }
        
        public Task<Token> GetTokenAsync(string code, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
            
            // using var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://bitbucket.org/site/oauth2/access_token");
            // var authData = Encoding.ASCII.GetBytes($"{_bitbucket.Options.Key}:{_bitbucket.Options.Secret}");
            // requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authData));
            // var dict = new Dictionary<string, string>();
            // dict.Add("code", code);
            // dict.Add("grant_type", "authorization_code");
            // requestMessage.Content = new FormUrlEncodedContent(dict);
            // var response = await _client.ApiClient.SendAsync(requestMessage);
            //
            // if (response.IsSuccessStatusCode)
            // {
            //     var model = await response.Content.ReadAsAsync<BitbucketToken>();
            //     return _mapper.Map(model);
            // }
            // else
            // {
            //     throw new ExternalApiException(response.ReasonPhrase);
            // }
        }
    }
}