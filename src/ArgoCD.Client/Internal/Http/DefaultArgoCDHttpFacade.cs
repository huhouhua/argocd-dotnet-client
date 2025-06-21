using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArgoCD.Client.Internal.Http.Serialization;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Session.Requests;
using ArgoCD.Client.Models.Session.Responses;

namespace ArgoCD.Client.Internal.Http
{
    internal sealed class DefaultArgoCDHttpFacade : IArgoCDHttpFacade
    {
        private readonly HttpClient _httpClient;
        private ArgoCDApiRequestor _requestor;

        public DefaultArgoCDHttpFacade(Func<HttpClient> clientFactoryFunc, RequestsJsonSerializer jsonSerializer)
        {
            if (clientFactoryFunc == null)
            {
                _httpClient = new HttpClient();
            }
            else
            {
                _httpClient = clientFactoryFunc();
            }

            Setup(jsonSerializer);
        }

        public DefaultArgoCDHttpFacade(string hostUrl, RequestsJsonSerializer jsonSerializer,
            string authenticationToken = "", HttpMessageHandler httpMessageHandler = null,
            TimeSpan? clientTimeout = null)
        {
            _httpClient = new HttpClient(httpMessageHandler ?? new HttpClientHandler()) { BaseAddress = new Uri(hostUrl) };
            switch (authenticationToken.Length)
            {
                case int i when i == 0:
                    break;
                case int i when i == 257:
                    _httpClient.DefaultRequestHeaders.Add("Cookie", $"argocd.token={authenticationToken}");
                    break;
                case int i when i > 64:
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", authenticationToken);
                    break;
                default:
                    throw new ArgumentException(
                        "Unsupported authentication token provide, please private an oauth or private token");
            }
            if (clientTimeout.HasValue)
            {
                _httpClient.Timeout = clientTimeout.Value;
            }
            Setup(jsonSerializer);
        }

        public Task<T> GetAsync<T>(string uri, CancellationToken cancellationToken = default) =>
            _requestor.GetAsync<T>(uri, cancellationToken);

        public Task<T> PostAsync<T>(string uri, object data = null, CancellationToken cancellationToken = default)
            where T : class =>
            _requestor.PostAsync<T>(uri, data, cancellationToken);

        public Task PostAsync(string uri, object data = null, CancellationToken cancellationToken = default) =>
            _requestor.PostAsync(uri, data, cancellationToken);

        public Task<T> PutAsync<T>(string uri, object data, CancellationToken cancellationToken = default) =>
            _requestor.PutAsync<T>(uri, data, cancellationToken);

        public Task PutAsync(string uri, object data, CancellationToken cancellationToken = default) =>
            _requestor.PutAsync(uri, data, cancellationToken);

        public Task DeleteAsync(string uri, CancellationToken cancellationToken = default) =>
            _requestor.DeleteAsync(uri, cancellationToken);

        public Task<T> DeleteAsync<T>(string uri, CancellationToken cancellationToken = default) =>
            _requestor.DeleteAsync<T>(uri, cancellationToken);

        public Task DeleteAsync(string uri, object data, CancellationToken cancellationToken = default) =>
            _requestor.DeleteAsync(uri, data, cancellationToken);

        public Task<T> PatchAsync<T>(string uri, object data, CancellationToken cancellationToken = default) =>
            _requestor.PatchAsync<T>(uri, data, cancellationToken);

        public Task PatchAsync(string uri, object data, CancellationToken cancellationToken = default) =>
            _requestor.PatchAsync(uri, data, cancellationToken);

        private void Setup(RequestsJsonSerializer jsonSerializer)
        {
            // allow tls 1.1 and 1.2
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            _requestor = new ArgoCDApiRequestor(_httpClient, jsonSerializer);
        }

        public async Task<Session> LoginAsync(CreateSessionRequest sessionRequest)
        {
            string url = $"{_httpClient.BaseAddress}session";
            var sessionTokenResponse = await _requestor.PostAsync<Session>(url, sessionRequest);
            // _httpClient.DefaultRequestHeaders.Authorization =
            //     new AuthenticationHeaderValue("Bearer", sessionTokenResponse.Token);
            return sessionTokenResponse;
        }
    }
}
