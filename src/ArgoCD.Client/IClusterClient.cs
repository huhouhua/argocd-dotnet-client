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
using ArgoCD.Client.Models.Cluster.Requests;
using ArgoCD.Client.Models.Cluster.Responses;
using ArgoCD.Client.Models;

namespace ArgoCD.Client
{
    public interface IClusterClient
    {
        /// <summary>
        ///  List returns list of clusters
        /// </summary>
        /// <param name="options">get options <see cref="ClusterQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1ClusterList> GetListAsync(Action<ClusterQueryOptions> options, CancellationToken cancellationToken = default);


        /// <summary>
        ///  Get returns a cluster by server address
        /// </summary>
        /// <param name="options">get options <see cref="ClusterQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1Cluster> GetAsync(Action<ClusterQueryOptions> options,CancellationToken cancellationToken = default);

        /// <summary>
        /// Create creates a cluster
        /// </summary>
        /// <param name="request">Create cluster request</param>
        /// <param name="options">Create options <see cref="UpsertOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1Cluster> CreateClusterAsync(V1alpha1ClusterRequest request, Action<UpsertOptions> options, CancellationToken cancellationToken = default);


        /// <summary>
        /// Update updates a cluster
        /// </summary>
        /// <param name="request">Update cluster request</param>
        /// <param name="options">Update options <see cref="UpdateClusterOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1Cluster> UpdateClusterAsync(V1alpha1ClusterRequest request, Action<UpdateClusterOptions> options, CancellationToken cancellationToken = default);


        /// <summary>
        /// Delete deletes a cluster
        /// </summary>
        /// <param name="request">Delete cluster request</param>
        /// <param name="options">Delete options <see cref="ClusterQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task DeleteClusterAsync(V1alpha1ClusterRequest request, Action<ClusterQueryOptions> options, CancellationToken cancellationToken = default);


        /// <summary>
        /// InvalidateCache invalidates cluster cache
        /// </summary>
        /// <param name="idValue">value holds the cluster server URL or cluster name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task InvalidateCacheAsync(string idValue, CancellationToken cancellationToken = default);


        /// <summary>
        /// RotateAuth rotates the bearer token used for a cluster
        /// </summary>
        /// <param name="idValue">value holds the cluster server URL or cluster name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task RotateAuthAsync(string idValue, CancellationToken cancellationToken = default);
    }
}
