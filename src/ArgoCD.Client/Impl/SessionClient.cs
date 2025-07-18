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
using System.Threading;
using System.Threading.Tasks;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Session.Requests;
using ArgoCD.Client.Models.Session.Responses;

namespace ArgoCD.Client.Impl
{
    public class SessionClient:ISessionClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;

        internal SessionClient(IArgoCDHttpFacade httpFacade) => _httpFacade = httpFacade;


        /// <summary>
        /// Get the current user's info
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<UserInfo> GetCurrentUserInfoAsync(CancellationToken cancellationToken = default) =>
              await _httpFacade.GetAsync<UserInfo>("session/userinfo",cancellationToken).
            ConfigureAwait(false);


        /// <summary>
        /// Create a new JWT for authentication and set a cookie if using HTTP
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<Session> CreateSessionAsync(CreateSessionRequest request, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(request, nameof(request));

           return await _httpFacade.PostAsync<Session>("session", request, cancellationToken).
                ConfigureAwait(false);
        }

        /// <summary>
        /// Delete an existing JWT cookie if using HTTP
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task DeleteCurrentSessionAsync(CancellationToken cancellationToken = default) =>
             await _httpFacade.DeleteAsync("session", cancellationToken).
            ConfigureAwait(false);

    }
}
