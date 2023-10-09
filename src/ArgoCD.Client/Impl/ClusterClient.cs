using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Models.Cluster.Responses;
using ArgoCD.Client.Models.Cluster.Requests;
using ArgoCD.Client.Internal.Queries;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Internal.Http;

namespace ArgoCD.Client.Impl
{
    public class ClusterClient: IClusterClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;
        private readonly ClusterQueryBuilder _clusterQueryBuilder;
        private readonly ClusterUpdateBuilder _clusterUpdateBuilder;
        private readonly ClusterCreateBuilder _clusterCreateBuilder;


        internal ClusterClient(IArgoCDHttpFacade httpFacade,
            ClusterQueryBuilder clusterQueryBuilder,
            ClusterUpdateBuilder clusterUpdateBuilder,
            ClusterCreateBuilder clusterCreateBuilder)
        {
            _httpFacade = httpFacade;
            _clusterQueryBuilder = clusterQueryBuilder;
            _clusterUpdateBuilder = clusterUpdateBuilder;
            _clusterCreateBuilder = clusterCreateBuilder;
        }


        /// <summary>
        ///  List returns list of clusters
        /// </summary>
        /// <param name="options">get options <see cref="ClusterQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1ClusterList> GetListAsync(Action<ClusterQueryOptions> options, CancellationToken cancellationToken = default)
        {
            var queryOptions = new ClusterQueryOptions();
            options?.Invoke(queryOptions);

            string url = _clusterQueryBuilder.Build("clusters", queryOptions);
            return await _httpFacade.GetAsync<V1alpha1ClusterList>(url, cancellationToken).ConfigureAwait(false);

        }


        /// <summary>
        ///  Get returns a cluster by server address
        /// </summary>
        /// <param name="options">get options <see cref="ClusterQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1Cluster> GetAsync(Action<ClusterQueryOptions> options, CancellationToken cancellationToken = default)
        {
            var queryOptions = new ClusterQueryOptions();
            options?.Invoke(queryOptions);
            Guard.NotNullOrDefault(queryOptions.IdValue, nameof(queryOptions.IdValue));

            string url = _clusterQueryBuilder.Build($"clusters/{queryOptions.IdValue}", queryOptions);
            return await _httpFacade.GetAsync<V1alpha1Cluster>(url, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create creates a cluster
        /// </summary>
        /// <param name="request">Create cluster request</param>
        /// <param name="options">Create options <see cref="CreateClusterOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1Cluster> CreateClusterAsync(V1alpha1ClusterRequest request, Action<CreateClusterOptions> options, CancellationToken cancellationToken = default)
        {
            var createOptions = new CreateClusterOptions();
            options?.Invoke(createOptions);

            string url = _clusterCreateBuilder.Build("clusters", createOptions);
            return await _httpFacade.PostAsync<V1alpha1Cluster>(url, request, cancellationToken).ConfigureAwait(false);
        }


        /// <summary>
        /// Update updates a cluster
        /// </summary>
        /// <param name="request">Update cluster request</param>
        /// <param name="options">Update options <see cref="UpdateClusterOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1Cluster> UpdateClusterAsync(V1alpha1ClusterRequest request, Action<UpdateClusterOptions> options, CancellationToken cancellationToken = default)
        {
            var updateOptions = new UpdateClusterOptions();
            options?.Invoke(updateOptions);
            Guard.NotNullOrDefault(updateOptions.IdValue, nameof(updateOptions.IdValue));

            string url = _clusterUpdateBuilder.Build($"clusters/{updateOptions.IdValue}", updateOptions);
            return await _httpFacade.PutAsync<V1alpha1Cluster>(url, request, cancellationToken).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete deletes a cluster
        /// </summary>
        /// <param name="request">Delete cluster request</param>
        /// <param name="options">Delete options <see cref="ClusterQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task DeleteClusterAsync(V1alpha1ClusterRequest request, Action<ClusterQueryOptions> options, CancellationToken cancellationToken = default)
        {
            var queryOptions = new ClusterQueryOptions();
            options?.Invoke(queryOptions);
            Guard.NotNullOrDefault(queryOptions.IdValue, nameof(queryOptions.IdValue));

            string url = _clusterQueryBuilder.Build($"clusters/{queryOptions.IdValue}", queryOptions);
             await _httpFacade.DeleteAsync(url, cancellationToken).ConfigureAwait(false);
        }


        /// <summary>
        /// InvalidateCache invalidates cluster cache
        /// </summary>
        /// <param name="idValue">value holds the cluster server URL or cluster name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task InvalidateCacheAsync(string idValue, CancellationToken cancellationToken = default) =>
            await _httpFacade.PostAsync($"clusters/{idValue}/invalidate-cache",cancellationToken).ConfigureAwait(false);


        /// <summary>
        /// RotateAuth rotates the bearer token used for a cluster
        /// </summary>
        /// <param name="idValue">value holds the cluster server URL or cluster name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task RotateAuthAsync(string idValue, CancellationToken cancellationToken = default) =>
            await _httpFacade.PostAsync($"clusters/{idValue}/rotate-auth",cancellationToken).ConfigureAwait(false);

    }
}
