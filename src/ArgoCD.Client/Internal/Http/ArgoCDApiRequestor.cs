using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArgoCD.Client.Internal.Http.Serialization;

namespace ArgoCD.Client.Internal.Http
{
    internal class ArgoCDApiRequestor
    {

        private readonly Func<HttpClient> _clientFunc;
        private readonly RequestsJsonSerializer _jsonSerializer;


        public ArgoCDApiRequestor(Func<HttpClient> clientFunc, RequestsJsonSerializer jsonSerializer)
        {
            _clientFunc = clientFunc;
            _jsonSerializer = jsonSerializer;
        }


        public async Task<T> GetAsync<T>(string url, CancellationToken cancellationToken = default)
        {
            using HttpClient client = _clientFunc();
            using var responseMessage = await client.GetAsync(url, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
            return await ReadResponseAsync<T>(responseMessage);
        }

        public async Task<T> PostAsync<T>(string url, object data = null, CancellationToken cancellationToken = default)
        {
            using HttpClient client = _clientFunc();
            using StringContent content = SerializeToString(data);
            using var responseMessage = await client.PostAsync(url, content, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
            return await ReadResponseAsync<T>(responseMessage);
        }


        public async Task PostAsync(string url, object data = null, CancellationToken cancellationToken = default)
        {
            using HttpClient client = _clientFunc();
            using StringContent content = SerializeToString(data);
            using var responseMessage = await client.PostAsync(url, content, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
        }

        public async Task<T> PutAsync<T>(string url, object data, CancellationToken cancellationToken = default)
        {
            using HttpClient client = _clientFunc();
            using StringContent content = SerializeToString(data);
            using var responseMessage = await client.PutAsync(url, content, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
            return await ReadResponseAsync<T>(responseMessage);
        }

        public async Task PutAsync(string url, object data, CancellationToken cancellationToken = default)
        {
            using HttpClient client = _clientFunc();
            using StringContent content = SerializeToString(data);
            using var responseMessage = await client.PutAsync(url, content, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
        }

        public async Task<T> PatchAsync<T>(string url, object data, CancellationToken cancellationToken = default)
        {
            using HttpClient client = _clientFunc();
            using StringContent content = SerializeToString(data);
#if NET5_0 || NET6_0 || NETCOREAPP3_1
            using var responseMessage = await client.PatchAsync(url, content, cancellationToken).
                 ConfigureAwait(false);
#else
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), url)
            {
                Content = content
            };
            using var responseMessage = await client.SendAsync(request, cancellationToken).
                ConfigureAwait(false);
            #endif

            await EnsureSuccessStatusCodeAsync(responseMessage);
            return await ReadResponseAsync<T>(responseMessage);
        }

        public async Task PatchAsync(string url, object data, CancellationToken cancellationToken = default)
        {
            using HttpClient client = _clientFunc();
            using StringContent content = SerializeToString(data);
#if NET5_0 || NET6_0 || NETCOREAPP3_1
            using var responseMessage = await client.PatchAsync(url, content, cancellationToken).
                 ConfigureAwait(false);
#else
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), url)
            {
                Content = content
            };
            using var responseMessage = await client.SendAsync(request, cancellationToken).
                ConfigureAwait(false);
#endif

            await EnsureSuccessStatusCodeAsync(responseMessage);

        }

        public async Task DeleteAsync(string url, CancellationToken cancellationToken = default)
        {
            using HttpClient client = _clientFunc();
            using var responseMessage = await client.DeleteAsync(url, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
        }
        public async Task<T> DeleteAsync<T>(string url, CancellationToken cancellationToken = default)
        {
            using HttpClient client = _clientFunc();
            using var responseMessage = await client.DeleteAsync(url, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
            return await ReadResponseAsync<T>(responseMessage);
        }

        public async Task DeleteAsync(string url, object data, CancellationToken cancellationToken = default)
        {
            using HttpClient client = _clientFunc();
            using var request = new HttpRequestMessage(HttpMethod.Delete, url)
            {
                Content = SerializeToString(data)
            };
            var responseMessage = await client.SendAsync(request, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
        }

        public async Task<Tuple<T, HttpResponseHeaders>> GetWithHeadersAsync<T>(string url, CancellationToken cancellationToken = default)
        {
            using HttpClient client = _clientFunc();
            using var responseMessage = await client.GetAsync(url, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
            return Tuple.Create(await ReadResponseAsync<T>(responseMessage), responseMessage.Headers);
        }

        private static async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage responseMessage)
        {
            if (responseMessage.IsSuccessStatusCode)
                return;

            string errorResponse = await responseMessage.Content.ReadAsStringAsync().
                ConfigureAwait(false);
            throw new ArgoCDException(responseMessage.StatusCode, errorResponse ?? "");
        }

        private async Task<T> ReadResponseAsync<T>(HttpResponseMessage responseMessage)
        {
            string response = await responseMessage.Content.ReadAsStringAsync().
                ConfigureAwait(false);
            var result = _jsonSerializer.Deserialize<T>(response);
            return result;
        }


        private StringContent SerializeToString(object data)
        {
            string serializedObject = _jsonSerializer.Serialize(data);

            var content = data != null ?
                new StringContent(serializedObject) :
                new StringContent(string.Empty);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }
    }
}
