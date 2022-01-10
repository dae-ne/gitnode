using System.Net.Http;

namespace GitNode.Infrastructure.ExternalApis
{
    internal abstract class ApiBase
    {
        protected abstract HttpClient CreateHttpClient();
    }
}