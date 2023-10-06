using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Models.RepoCreds.Responses;
using ArgoCD.Client.Models.RepoCreds.Requests;
using ArgoCD.Client.Internal.Queries;

namespace ArgoCD.Client.Impl
{
    public  class RepoCredsClient: IRepoCredsClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;
        private readonly RepoCredsListQueryBuilder _repoCredsListQueryBuilder;
        private readonly RepoCredsCreateBuilder _repoCredsCreateBuilder;



        internal RepoCredsClient(IArgoCDHttpFacade httpFacade,
            RepoCredsListQueryBuilder repoCredsListQueryBuilder,
            RepoCredsCreateBuilder repoCredsCreateBuilder)
        {
            _httpFacade = httpFacade;
            _repoCredsListQueryBuilder = repoCredsListQueryBuilder;
            _repoCredsCreateBuilder = repoCredsCreateBuilder;
        }

        /// <summary>
        ///  gets a list of all configured repository credential sets
        /// </summary>
        /// <param name="options">get options <see cref="RepoCredsQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1RepoCredsList> GetListAsync(Action<RepoCredsQueryOptions> options, CancellationToken cancellationToken = default)
        {
            var queryOptions = new RepoCredsQueryOptions();
            options?.Invoke(queryOptions);

            string url = _repoCredsListQueryBuilder.Build("repocreds", queryOptions);
            return await _httpFacade.GetAsync<V1alpha1RepoCredsList>(url, cancellationToken).ConfigureAwait(false);
        }


        /// <summary>
        ///  creates a new repository credential set
        /// </summary>
        /// <param name="request">Create repository credentials request</param>
        /// <param name="options">Create options <see cref="CreateRepoCredsOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1RepoCreds> CreateRepositoryCredentialsAsync(CreateRepoCredsRequest request, Action<CreateRepoCredsOptions> options, CancellationToken cancellationToken = default)
        {
            var createOptions = new CreateRepoCredsOptions();
            options?.Invoke(createOptions);

            string url = _repoCredsCreateBuilder.Build("repocreds", createOptions);
            return await _httpFacade.PostAsync<V1alpha1RepoCreds>(url, cancellationToken).ConfigureAwait(false);

        }


        /// <summary>
        ///  updates a repository credential set
        /// </summary>
        /// <param name="credsUrl">URL is the URL that this credentials matches to</param>
        /// <param name="request">Update repository credentials request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1RepoCreds> UpdateRepositoryCredentialsAsync(string credsUrl, UpdateRepoCredsRequest request, CancellationToken cancellationToken = default) =>
            await _httpFacade.PutAsync<V1alpha1RepoCreds>($"repocreds/{credsUrl}", request, cancellationToken).ConfigureAwait(false);


        /// <summary>
        ///  deletes a repository credential set from the configuration
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task DeleteRepositoryCredentialsAsync(string url, CancellationToken cancellationToken = default) =>
            await _httpFacade.DeleteAsync($"repocreds/{url}", cancellationToken).ConfigureAwait(false);
    }
}
