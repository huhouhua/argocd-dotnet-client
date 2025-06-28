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
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Models.Session.Responses;
using ArgoCD.Client.Models.Session.Requests;

namespace ArgoCD.Client.Internal.Http
{
    internal interface IArgoCDHttpFacade
    {

        Task<T> GetAsync<T>(string uri, CancellationToken cancellationToken = default);

        Task<T> PostAsync<T>(string uri, object data = null, CancellationToken cancellationToken = default) where T : class;

        Task PostAsync(string uri, object data = null, CancellationToken cancellationToken = default);

        Task<T> PutAsync<T>(string uri, object data, CancellationToken cancellationToken = default);

        Task PutAsync(string uri, object data, CancellationToken cancellationToken = default);

        Task<T> PatchAsync<T>(string uri, object data, CancellationToken cancellationToken = default);

        Task PatchAsync(string uri, object data, CancellationToken cancellationToken = default);

        Task DeleteAsync(string uri, CancellationToken cancellationToken = default);

        Task<T> DeleteAsync<T>(string uri, CancellationToken cancellationToken = default);

        Task DeleteAsync(string uri, object data, CancellationToken cancellationToken = default);

        Task<Session> LoginAsync(CreateSessionRequest sessionRequest);
    }
}
