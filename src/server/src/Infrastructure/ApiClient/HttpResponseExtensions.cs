using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GitNode.Infrastructure.ApiClient
{
    internal static class HttpResponseExtensions
    {
        internal static async Task<T> ReadContentAsync<T>(this HttpResponseMessage response) where T : class
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                ContractResolver = HttpClientConfiguration.SnakeCaseContractResolver
            });
        }
    }
}