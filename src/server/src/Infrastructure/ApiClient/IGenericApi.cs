using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GitNode.Infrastructure.ApiClient
{
    internal interface IGenericApi
    {
        HttpClient HttpClient { get; }
        
        Task<TResponse> GetAsync<TResponse>(string uri, CancellationToken cancellationToken) where TResponse : class;

        Task<TResponse> GetAuthorizedAsync<TResponse>(string uri, string token, CancellationToken cancellationToken)
            where TResponse : class;
        
        Task<TResponse> PostAsync<TResponse, TRequest>(
            string uri,
            TRequest request,
            CancellationToken cancellationToken)
            where TResponse : class
            where TRequest : class;
        
        Task<TResponse> PostAuthorizedAsync<TResponse, TRequest>(
            string uri,
            string token,
            TRequest request,
            CancellationToken cancellationToken)
            where TResponse : class
            where TRequest : class;
        
        Task<TResponse> PutAuthorizedAsync<TResponse, TRequest>(
            string uri,
            string token,
            TRequest request,
            CancellationToken cancellationToken)
            where TResponse : class
            where TRequest : class;
        
        Task<TResponse> PatchAuthorizedAsync<TResponse, TRequest>(
            string uri,
            string token,
            TRequest request,
            CancellationToken cancellationToken)
            where TResponse : class
            where TRequest : class;
    }
}