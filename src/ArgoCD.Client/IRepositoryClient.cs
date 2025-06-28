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
using ArgoCD.Client.Models.Repository.Responses;
using ArgoCD.Client.Models.Repository.Requests;

namespace ArgoCD.Client
{
    public interface IRepositoryClient
    {
        /// <summary>
        ///  GetListAsync gets a list of all configured repositories
        /// </summary>
        /// <param name="options">get options <see cref="RepositoryQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1RepositoryList> GetListAsync(Action<RepositoryQueryOptions> options, CancellationToken cancellationToken = default);


        /// <summary>
        /// CreateRepositoryAsync creates a new repository configuration
        /// </summary>
        /// <param name="request">Create repository request</param>
        /// <param name="options">Create options <see cref="CreateRepositoryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1Repository> CreateRepositoryAsync(CreateRepositoryRequest request, Action<CreateRepositoryOptions> options, CancellationToken cancellationToken = default);


        /// <summary>
        ///UpdateRepositoryAsync  updates a repository configuration
        /// </summary>
        /// <param name="request">Update repository request</param>
        /// <param name="repo">Repo contains the URL to the remote repository</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1Repository> UpdateRepositoryAsync(string repo, CreateRepositoryRequest request, CancellationToken cancellationToken = default);


        /// <summary>
        /// GetRepositoryAsync returns a repository or its credentials
        /// </summary>
        /// <param name="repo">Repo contains the URL to the remote repository</param>
        /// <param name="options">get options <see cref="RepositoryRefreshOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1Repository> GetRepositoryAsync(string repo, Action<RepositoryRefreshOptions> options, CancellationToken cancellationToken = default);



        /// <summary>
        ///  DeleteRepositoryAsync a repository from the configuration
        /// </summary>
        /// <param name="repo">Repo URL for query</param>
        /// <param name="options">get options <see cref="RepositoryRefreshOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task DeleteRepositoryAsync(string repo, Action<RepositoryRefreshOptions> options, CancellationToken cancellationToken = default);


        /// <summary>
        ///   returns list of apps in the repo
        /// </summary>
        /// <param name="options">get options <see cref="RepositoryQueryAppOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<RepositoryRepoApps> GetAppByListAsync(string repo, Action<RepositoryQueryAppOptions> options, CancellationToken cancellationToken = default);



        /// <summary>
        ///  GetHelmChartByListAsync returns list of helm charts in the specified repository
        /// </summary>
        /// <param name="options">get options <see cref="RepositoryQueryAppOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<RepositoryHelmCharts> GetHelmChartByListAsync(string repo, Action<RepositoryRefreshOptions> options, CancellationToken cancellationToken = default);



        /// <summary>
        /// GetRepositoryRefsAsync  returns branches list 
        /// </summary>
        /// <param name="repo">Repo URL for query</param>
        /// <param name="options">get options <see cref="RepositoryRefreshOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<RepositoryRefs> GetRepositoryRefsAsync(string repo, Action<RepositoryRefreshOptions> options, CancellationToken cancellationToken = default);



        /// <summary>
        ///  ValidateAccessAsync validates access to a repository with given parameters
        /// </summary>
        /// <param name="repo">The URL to the repo</param>
        /// <param name="body">The URL to the repo</param>
        /// <param name="options">validate  options <see cref="ValidateAccessOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task ValidateAccessAsync(string repo, string body,  Action<ValidateAccessOptions> options, CancellationToken cancellationToken = default);



        /// <summary>
        ///  GetAppDetailsAsync returns application details by given path
        /// </summary>
        /// <param name="repoURL">RepoURL is the URL to the repository (Git or Helm) that contains the application manifests</param>
        /// <param name="request">Get app details request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<RepositoryRepoAppDetails> GetAppDetailsAsync(string repoURL, AppDetailsRequest request, CancellationToken cancellationToken = default);
    }
}
