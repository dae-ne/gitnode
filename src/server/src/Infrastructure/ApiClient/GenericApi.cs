using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Exceptions;

namespace GitNode.Infrastructure.ApiClient
{
    internal class GenericApi : IGenericApi
    {
        private readonly string _authorization;

        public GenericApi(string authorization) : this(authorization, new HttpClient())
        {
            
        }
        
        public GenericApi(string authorization, HttpClient client)
        {
            _authorization = authorization;
            HttpClient = client;
        }
        
        public HttpClient HttpClient { get; }

        public async Task<TResponse> GetAsync<TResponse>(string uri, CancellationToken cancellationToken)
            where TResponse : class
        {
            using var response = await HttpClient.GetAsync(uri, cancellationToken);
            return await HandleResponseAsync<TResponse>(response);
        }

        public async Task<TResponse> GetAuthorizedAsync<TResponse>(
            string uri,
            string token,
            CancellationToken cancellationToken)
            where TResponse : class
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(_authorization, token);
            var response = await HttpClient.SendAsync(requestMessage, cancellationToken);
            return await HandleResponseAsync<TResponse>(response);
        }

        public async Task<TResponse> PostAsync<TResponse, TRequest>(
            string uri,
            TRequest request,
            CancellationToken cancellationToken)
            where TResponse : class
            where TRequest : class
        {
            using var body = request.ToStringContent();
            using var response = await HttpClient.PostAsync(uri, body, cancellationToken);
            return await HandleResponseAsync<TResponse>(response);
        }

        public Task<TResponse> PostAuthorizedAsync<TResponse, TRequest>(
            string uri,
            string token,
            TRequest request,
            CancellationToken cancellationToken)
            where TResponse : class
            where TRequest : class =>
            SendAuthorizedAsync<TResponse, TRequest>(HttpMethod.Post, uri, token, request, cancellationToken);

        public Task<TResponse> PutAuthorizedAsync<TResponse, TRequest>(
            string uri,
            string token,
            TRequest request,
            CancellationToken cancellationToken)
            where TResponse : class
            where TRequest : class =>
            SendAuthorizedAsync<TResponse, TRequest>(HttpMethod.Put, uri, token, request, cancellationToken);

        public Task<TResponse> PatchAuthorizedAsync<TResponse, TRequest>(
            string uri,
            string token,
            TRequest request,
            CancellationToken cancellationToken)
            where TResponse : class
            where TRequest : class =>
            SendAuthorizedAsync<TResponse, TRequest>(HttpMethod.Patch, uri, token, request, cancellationToken);

        private static Task<T> HandleResponseAsync<T>(HttpResponseMessage response) where T : class =>
            response.IsSuccessStatusCode
                ? response.ReadContentAsync<T>()
                : throw new ExternalApiException((int)response.StatusCode, response.ReasonPhrase);
        
        private async Task<TResponse> SendAuthorizedAsync<TResponse, TRequest>(
            HttpMethod method,
            string uri,
            string token,
            TRequest request,
            CancellationToken cancellationToken)
            where TResponse : class
            where TRequest : class
        {
            using var body = request.ToStringContent();
            using var requestMessage = new HttpRequestMessage(method, uri);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(_authorization, token);
            requestMessage.Content = body;
            var response = await HttpClient.SendAsync(requestMessage, cancellationToken);
            return await HandleResponseAsync<TResponse>(response);
        }
    }
}