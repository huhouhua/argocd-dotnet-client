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
using ArgoCD.Client.Models.Notification.Responses;
using ArgoCD.Client.Internal.Http;

namespace ArgoCD.Client.Impl
{
    public sealed class NotificationClient: INotificationClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;

        internal NotificationClient(IArgoCDHttpFacade httpFacade) => _httpFacade = httpFacade;

        /// <summary>
        ///List returns list of services
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<NotificationServiceList> GetServiceByListAsync(CancellationToken cancellationToken = default) =>
           await _httpFacade.GetAsync<NotificationServiceList>("notifications/services", cancellationToken).ConfigureAwait(false);



        /// <summary>
        ///List returns list of templates
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<NotificationServiceList> GetTemplateByListAsync(CancellationToken cancellationToken = default) =>
            await _httpFacade.GetAsync<NotificationServiceList>("notifications/templates", cancellationToken).ConfigureAwait(false);



        /// <summary>
        ///List returns list of triggers
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<NotificationServiceList> GetTriggersByListAsync(CancellationToken cancellationToken = default) =>
            await _httpFacade.GetAsync<NotificationServiceList>("notifications/triggers", cancellationToken).ConfigureAwait(false);
    }
}
