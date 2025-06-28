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
using ArgoCD.Client.Models;
using ArgoCD.Client.Models.ApplicationSet.Reponses;
using ArgoCD.Client.Models.ApplicationSet.Requests;
using ArgoCD.Client.Models.GPKKey.Responses;

namespace ArgoCD.Client
{
    public interface IApplicationSetClient
    {
        /// <summary>
        /// List returns list of applicationset
        /// </summary>
        /// <param name="options">Get options <see cref="ApplicationSetListQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1ApplicationSetList> GetListAsync(Action<ApplicationSetListQueryOptions> options, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get returns an applicationset by name
        /// </summary>
        /// <param name="name">the applicationsets's name</param>
        /// <param name="options">Get options <see cref="ApplicationSetQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1ApplicationSet> GetAsync(string name, Action<ApplicationSetQueryOptions> options, CancellationToken cancellationToken = default);


        /// <summary>
        /// Create creates an applicationset
        /// </summary>
        /// <param name="request">Create applicationset request</param>
        /// <param name="options">Create options <see cref="UpsertOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1ApplicationSet> CreateApplicationSetAsync(CreateApplicationSetRequest request, Action<UpsertOptions> options, CancellationToken cancellationToken = default);


        /// <summary>
        /// Delete deletes an application set
        /// </summary>
        /// <param name="name">the applicationsets's name</param>
        /// <param name="options">delete options <see cref="ApplicationSetQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<DeleteApplicationSetResult> DeleteAsync(string name, Action<ApplicationSetQueryOptions> options, CancellationToken cancellationToken = default);

    }
}
