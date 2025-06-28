// Copyright 2024 The argocd-dotnet-client Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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

        private readonly HttpClient _client;
        private readonly RequestsJsonSerializer _jsonSerializer;
        public ArgoCDApiRequestor(HttpClient client, RequestsJsonSerializer jsonSerializer)
        {
            _client = client;
            _jsonSerializer = jsonSerializer;
        }
        public async Task<T> GetAsync<T>(string url, CancellationToken cancellationToken = default)
        {
            using var responseMessage = await _client.GetAsync(url, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
            return await ReadResponseAsync<T>(responseMessage);
        }

        public async Task<T> PostAsync<T>(string url, object data = null, CancellationToken cancellationToken = default)
        {
            using StringContent content = SerializeToString(data);
            using var responseMessage = await _client.PostAsync(url, content, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
            return await ReadResponseAsync<T>(responseMessage);
        }


        public async Task PostAsync(string url, object data = null, CancellationToken cancellationToken = default)
        {
            using StringContent content = SerializeToString(data);
            using var responseMessage = await _client.PostAsync(url, content, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
        }

        public async Task<T> PutAsync<T>(string url, object data, CancellationToken cancellationToken = default)
        {
            using StringContent content = SerializeToString(data);
            using var responseMessage = await _client.PutAsync(url, content, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
            return await ReadResponseAsync<T>(responseMessage);
        }

        public async Task PutAsync(string url, object data, CancellationToken cancellationToken = default)
        {
            using StringContent content = SerializeToString(data);
            using var responseMessage = await _client.PutAsync(url, content, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
        }

        public async Task<T> PatchAsync<T>(string url, object data, CancellationToken cancellationToken = default)
        {
            using StringContent content = SerializeToString(data);
#if NET5_0 || NET6_0 || NETCOREAPP3_1
            using var responseMessage = await _client.PatchAsync(url, content, cancellationToken).
                 ConfigureAwait(false);
#else
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), url)
            {
                Content = content
            };
            using var responseMessage = await _client.SendAsync(request, cancellationToken).
                ConfigureAwait(false);
            #endif

            await EnsureSuccessStatusCodeAsync(responseMessage);
            return await ReadResponseAsync<T>(responseMessage);
        }

        public async Task PatchAsync(string url, object data, CancellationToken cancellationToken = default)
        {
            using StringContent content = SerializeToString(data);
#if NET5_0 || NET6_0 || NETCOREAPP3_1
            using var responseMessage = await _client.PatchAsync(url, content, cancellationToken).
                 ConfigureAwait(false);
#else
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), url)
            {
                Content = content
            };
            using var responseMessage = await _client.SendAsync(request, cancellationToken).
                ConfigureAwait(false);
#endif

            await EnsureSuccessStatusCodeAsync(responseMessage);

        }

        public async Task DeleteAsync(string url, CancellationToken cancellationToken = default)
        {
            await DeleteAsync(url,null,cancellationToken);
        }
        public async Task<T> DeleteAsync<T>(string url, CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Delete, url)
            {
                Content = SerializeToString(null),
            };
            var responseMessage = await _client.SendAsync(request, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
            return await ReadResponseAsync<T>(responseMessage);
        }

        public async Task DeleteAsync(string url, object data, CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Delete, url)
            {
                Content = SerializeToString(data),
            };
            var responseMessage = await _client.SendAsync(request, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
        }

        public async Task<Tuple<T, HttpResponseHeaders>> GetWithHeadersAsync<T>(string url, CancellationToken cancellationToken = default)
        {
            using var responseMessage = await _client.GetAsync(url, cancellationToken).
                ConfigureAwait(false);
            await EnsureSuccessStatusCodeAsync(responseMessage);
            return Tuple.Create(await ReadResponseAsync<T>(responseMessage), responseMessage.Headers);
        }

        private  async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage responseMessage)
        {
            if (responseMessage.IsSuccessStatusCode)
                return;

            string errorResponse = await responseMessage.Content.ReadAsStringAsync().
                ConfigureAwait(false);

            var runtimeError = _jsonSerializer.Deserialize<RuntimeError>(errorResponse);
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
