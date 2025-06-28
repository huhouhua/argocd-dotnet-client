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
using ArgoCD.Client.Models.RepoCreds.Responses;
using ArgoCD.Client.Models.RepoCreds.Requests;
using ArgoCD.Client.Internal.Builders;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Models;
using ArgoCD.Client.Internal.Utilities;

namespace ArgoCD.Client.Impl
{
    public  class RepoCredsClient: IRepoCredsClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;
        private readonly RepoCredsListQueryBuilder _repoCredsListQueryBuilder;
        private readonly UpsertBuilder _upsertBuilder;



        internal RepoCredsClient(IArgoCDHttpFacade httpFacade,
            RepoCredsListQueryBuilder repoCredsListQueryBuilder,
            UpsertBuilder upsertBuilder)
        {
            _httpFacade = httpFacade;
            _repoCredsListQueryBuilder = repoCredsListQueryBuilder;
            _upsertBuilder = upsertBuilder;
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
            return await _httpFacade.GetAsync<V1alpha1RepoCredsList>(url, cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        ///  creates a new repository credential set
        /// </summary>
        /// <param name="request">Create repository credentials request</param>
        /// <param name="options">Create options <see cref="UpsertOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1RepoCreds> CreateRepositoryCredentialsAsync(CreateRepoCredsRequest request, Action<UpsertOptions> options, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(request, nameof(request));

            var createOptions = new UpsertOptions();
            options?.Invoke(createOptions);

            string url = _upsertBuilder.Build("repocreds", createOptions);
            return await _httpFacade.PostAsync<V1alpha1RepoCreds>(url,request, cancellationToken).
                ConfigureAwait(false);

        }


        /// <summary>
        ///  updates a repository credential set
        /// </summary>
        /// <param name="credsUrl">URL is the URL that this credentials matches to</param>
        /// <param name="request">Update repository credentials request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1RepoCreds> UpdateRepositoryCredentialsAsync(string credsUrl, UpdateRepoCredsRequest request, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(credsUrl, nameof(credsUrl));
            Guard.NotNull(request, nameof(request));

           return  await _httpFacade.PutAsync<V1alpha1RepoCreds>($"repocreds/{credsUrl}", request, cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        ///  deletes a repository credential set from the configuration
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task DeleteRepositoryCredentialsAsync(string url, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(url, nameof(url));
             await _httpFacade.DeleteAsync($"repocreds/{url}", cancellationToken).
             ConfigureAwait(false);
        }
    }
}
