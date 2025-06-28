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
using ArgoCD.Client.Models.Settings.Responses;

namespace ArgoCD.Client.Impl
{
    public class SettingsClient : ISettingsClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;

        internal SettingsClient(IArgoCDHttpFacade httpFacade) => _httpFacade = httpFacade;

        /// <summary>
        /// Get returns Argo CD settings
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ClusterSettings> GetSettingsAsync(CancellationToken cancellationToken = default) =>
            await _httpFacade.GetAsync<ClusterSettings>("settings", cancellationToken).
            ConfigureAwait(false);


        /// <summary>
        /// Get returns Argo CD plugins
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ClusterSettingsPlugins> GetPluginsAsync(CancellationToken cancellationToken = default) =>
            await _httpFacade.GetAsync<ClusterSettingsPlugins>("settings/plugins", cancellationToken).
            ConfigureAwait(false);

    }
}
