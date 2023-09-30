using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArgoCD.Client.Internal.Http.Serialization;
using ArgoCD.Client.Internal.Utilities;

namespace ArgoCD.Client.Internal.Http
{
    internal sealed class ArgoCDHttpFacade
    {
        private readonly Func<HttpClient> _httpClientFunc;
        private ArgoCDApiRequestor _requestor;

        public ArgoCDHttpFacade(string hostUrl,
            RequestsJsonSerializer jsonSerializer,
              HttpMessageHandler httpMessageHandler,
            TimeSpan? clientTimeout = null)
        {
            _httpClientFunc = () =>
            {
                var client = new HttpClient(httpMessageHandler ?? new HttpClientHandler()) { BaseAddress = new Uri(hostUrl) };
                if (clientTimeout.HasValue)
                {
                    client.Timeout = clientTimeout.Value;
                }
                return client;
            };

            Setup(jsonSerializer);
        }

        public ArgoCDHttpFacade(IHttpClientFactory clientFactory, RequestsJsonSerializer jsonSerializer)
        {
            Guard.NotNull(clientFactory, nameof(clientFactory));
            _httpClientFunc = () => clientFactory.CreateClient();
            Setup(jsonSerializer);
        }

        public ArgoCDHttpFacade(IHttpClientFactory clientFactory, string clientName, RequestsJsonSerializer jsonSerializer)
        {
            Guard.NotNull(clientFactory, nameof(clientFactory));
            Guard.NotNullOrDefault(clientName, nameof(clientName));
            _httpClientFunc = () => clientFactory.CreateClient(clientName);
            Setup(jsonSerializer);
        }

        public ArgoCDHttpFacade(HttpClient client, RequestsJsonSerializer jsonSerializer)
        {
            Guard.NotNull(client, nameof(client));
            _httpClientFunc = ()=> client;
            Setup(jsonSerializer);
        }

        public ArgoCDHttpFacade(Func<HttpClient> clientFactoryFunc, RequestsJsonSerializer jsonSerializer)
        {
            if (clientFactoryFunc is null)
            {
                _httpClientFunc = () => new HttpClient();
            }
            else
            {
                _httpClientFunc = clientFactoryFunc;
            }
            Setup(jsonSerializer);
        }

        public Task<T> GetAsync<T>(string uri, CancellationToken cancellationToken = default) =>
          _requestor.GetAsync<T>(uri,cancellationToken);

        public Task<T> PostAsync<T>(string uri, object data = null, CancellationToken cancellationToken = default) where T : class =>
            _requestor.PostAsync<T>(uri, data,cancellationToken);

        public Task PostAsync(string uri, object data = null, CancellationToken cancellationToken = default) =>
            _requestor.PostAsync(uri, data,cancellationToken);

        public Task<T> PutAsync<T>(string uri, object data, CancellationToken cancellationToken = default) =>
            _requestor.PutAsync<T>(uri, data, cancellationToken);

        public Task Put(string uri, object data, CancellationToken cancellationToken = default) =>
            _requestor.PutAsync(uri, data, cancellationToken);

        public Task DeleteAsync(string uri, CancellationToken cancellationToken = default) =>
            _requestor.DeleteAsync(uri,cancellationToken);
        public Task Delete(string uri, object data, CancellationToken cancellationToken = default) =>
            _requestor.DeleteAsync(uri, data, cancellationToken);
        private void Setup(RequestsJsonSerializer jsonSerializer)
        {
            // allow tls 1.1 and 1.2
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            // ReSharper disable once InconsistentlySynchronizedField
            _requestor = new ArgoCDApiRequestor(_httpClientFunc, jsonSerializer);
        }
    }
}
