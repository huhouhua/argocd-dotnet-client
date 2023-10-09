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
    internal sealed class DefaultArgoCDHttpFacade: IArgoCDHttpFacade
    {
        private readonly Func<HttpClient> _httpClientFunc;
        private ArgoCDApiRequestor _requestor;

        public DefaultArgoCDHttpFacade(Func<HttpClient> clientFactoryFunc, RequestsJsonSerializer jsonSerializer)
        {
            if (clientFactoryFunc == null)
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

        public Task PutAsync(string uri, object data, CancellationToken cancellationToken = default) =>
            _requestor.PutAsync(uri, data, cancellationToken);

        public Task DeleteAsync(string uri, CancellationToken cancellationToken = default) =>
            _requestor.DeleteAsync(uri,cancellationToken);

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
            // ReSharper disable once InconsistentlySynchronizedField
            _requestor = new ArgoCDApiRequestor(_httpClientFunc, jsonSerializer);
        }
    }
}
