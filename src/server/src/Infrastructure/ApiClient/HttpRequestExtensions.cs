using System.Net.Http;
using Newtonsoft.Json;

namespace GitNode.Infrastructure.ApiClient
{
    internal static class HttpRequestExtensions
    {
        public static StringContent ToStringContent<TRequest>(this TRequest request) where TRequest : class
        {
            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = HttpClientConfiguration.SnakeCaseContractResolver
            });
            return new StringContent(
                json,
                HttpClientConfiguration.Encoding,
                HttpClientConfiguration.MediaType);
        }
    }
}