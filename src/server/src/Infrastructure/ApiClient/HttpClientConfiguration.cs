using System.Text;
using Newtonsoft.Json.Serialization;

namespace GitNode.Infrastructure.ApiClient
{
    internal static class HttpClientConfiguration
    {
        public static IContractResolver SnakeCaseContractResolver => new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        };

        public static Encoding Encoding => Encoding.UTF8;

        public const string MediaType = "application/json";
    }
}