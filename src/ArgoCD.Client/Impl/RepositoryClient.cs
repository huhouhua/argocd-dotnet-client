using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Models.Repository.Responses;
using ArgoCD.Client.Models.Repository.Requests;
using ArgoCD.Client.Internal.Builders;
using Microsoft.Extensions.Options;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Internal.Utilities;

namespace ArgoCD.Client.Impl
{
    public class RepositoryClient : IRepositoryClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;
        private readonly RepositoryQueryBuilder _repositoryQueryBuilder;
        private readonly CreateRepositoryBuilder _createRepositoryBuilder;
        private readonly RepositoryRefreshBuilder _repositoryRefreshBuilder;
        private readonly RepositoryQueryAppBuilder  _repositoryQueryAppBuilder;
        private readonly ValidateAccessBuilder _validateAccessBuilder;

        internal RepositoryClient(IArgoCDHttpFacade httpFacade,
            RepositoryQueryBuilder repositoryQueryBuilder,
            CreateRepositoryBuilder createRepositoryBuilder,
            RepositoryRefreshBuilder repositoryRefreshBuilder,
            RepositoryQueryAppBuilder repositoryQueryAppBuilder,
            ValidateAccessBuilder validateAccessBuilder)
        {
            _httpFacade = httpFacade;
            _repositoryQueryBuilder = repositoryQueryBuilder;
            _createRepositoryBuilder = createRepositoryBuilder;
            _repositoryRefreshBuilder = repositoryRefreshBuilder;
            _repositoryQueryAppBuilder = repositoryQueryAppBuilder;
            _validateAccessBuilder = validateAccessBuilder; 
        }



        /// <summary>
        ///  GetListAsync gets a list of all configured repositories
        /// </summary>
        /// <param name="options">get options <see cref="RepositoryQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1RepositoryList> GetListAsync(Action<RepositoryQueryOptions> options, CancellationToken cancellationToken = default)
        {
            var queryOptions = new RepositoryQueryOptions();
            options?.Invoke(queryOptions);

            string url = _repositoryQueryBuilder.Build("repositories", queryOptions);
            return await _httpFacade.GetAsync<V1alpha1RepositoryList>(url, cancellationToken).
                ConfigureAwait(false);

        }


        /// <summary>
        /// CreateRepositoryAsync creates a new repository configuration
        /// </summary>
        /// <param name="request">Create repository request</param>
        /// <param name="options">Create options <see cref="CreateRepositoryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1Repository> CreateRepositoryAsync(CreateRepositoryRequest request, Action<CreateRepositoryOptions> options, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(request, nameof(request));

            var createOptions = new CreateRepositoryOptions();
            options?.Invoke(createOptions);

            string url = _createRepositoryBuilder.Build("repositories", createOptions);
            return await _httpFacade.PostAsync<V1alpha1Repository>(url, request, cancellationToken).
                ConfigureAwait(false);

        }


        /// <summary>
        ///UpdateRepositoryAsync  updates a repository configuration
        /// </summary>
        /// <param name="request">Update repository request</param>
        /// <param name="repo">Repo contains the URL to the remote repository</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1Repository> UpdateRepositoryAsync(string repo, CreateRepositoryRequest request, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(repo, nameof(repo));
            Guard.NotNull(request, nameof(request));

           return await _httpFacade.PutAsync<V1alpha1Repository>($"repositories/{repo}", request, cancellationToken).
            ConfigureAwait(false);
        }


        /// <summary>
        /// GetRepositoryAsync returns a repository or its credentials
        /// </summary>
        /// <param name="repo">Repo contains the URL to the remote repository</param>
        /// <param name="options">get options <see cref="RepositoryRefreshOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1Repository> GetRepositoryAsync(string repo, Action<RepositoryRefreshOptions> options, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(repo, nameof(repo));
            var queryOptions = new RepositoryRefreshOptions();
            options?.Invoke(queryOptions);

            string url = _repositoryRefreshBuilder.Build($"repositories/{repo}", queryOptions);
            return await _httpFacade.GetAsync<V1alpha1Repository>(url, cancellationToken).
                ConfigureAwait(false);

        }


        /// <summary>
        ///  DeleteRepositoryAsync a repository from the configuration
        /// </summary>
        /// <param name="repo">Repo URL for query</param>
        /// <param name="options">get options <see cref="RepositoryRefreshOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task DeleteRepositoryAsync(string repo, Action<RepositoryRefreshOptions> options, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(repo, nameof(repo));
            var queryOptions = new RepositoryRefreshOptions();
            options?.Invoke(queryOptions);

            string url = _repositoryRefreshBuilder.Build($"repositories/{repo}", queryOptions);
            await _httpFacade.DeleteAsync(url, cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        ///   returns list of apps in the repo
        /// </summary>
        /// <param name="options">get options <see cref="RepositoryQueryAppOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<RepositoryRepoApps> GetAppByListAsync(string repo, Action<RepositoryQueryAppOptions> options, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(repo, nameof(repo));
            var queryOptions = new RepositoryQueryAppOptions();
            options?.Invoke(queryOptions);

            string url = _repositoryQueryAppBuilder.Build($"repositories/{repo}/apps", queryOptions);
           return  await _httpFacade.GetAsync<RepositoryRepoApps>(url, cancellationToken).
                ConfigureAwait(false);
        }



        /// <summary>
        ///  GetHelmChartByListAsync returns list of helm charts in the specified repository
        /// </summary>
        /// <param name="options">get options <see cref="RepositoryQueryAppOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<RepositoryHelmCharts> GetHelmChartByListAsync(string repo, Action<RepositoryRefreshOptions> options, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(repo, nameof(repo));
            var queryOptions = new RepositoryRefreshOptions();
            options?.Invoke(queryOptions);

            string url = _repositoryRefreshBuilder.Build($"repositories/{repo}/helmcharts", queryOptions);
            return await _httpFacade.GetAsync<RepositoryHelmCharts>(url, cancellationToken).
                ConfigureAwait(false);
        }



        /// <summary>
        /// GetRepositoryRefsAsync  returns branches list 
        /// </summary>
        /// <param name="repo">Repo URL for query</param>
        /// <param name="options">get options <see cref="RepositoryRefreshOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<RepositoryRefs> GetRepositoryRefsAsync(string repo, Action<RepositoryRefreshOptions> options, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(repo, nameof(repo));
            var queryOptions = new RepositoryRefreshOptions();
            options?.Invoke(queryOptions);

            string url = _repositoryRefreshBuilder.Build($"repositories/{repo}/helmcharts", queryOptions);
            return await _httpFacade.GetAsync<RepositoryRefs>(url, cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        ///  ValidateAccessAsync validates access to a repository with given parameters
        /// </summary>
        /// <param name="repo">The URL to the repo</param>
        /// <param name="body">The URL to the repo</param>
        /// <param name="options">validate  options <see cref="ValidateAccessOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task ValidateAccessAsync(string repo, string body, Action<ValidateAccessOptions> options, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(repo, nameof(repo));
            Guard.NotEmpty(body, nameof(body));
            var queryOptions = new ValidateAccessOptions();
            options?.Invoke(queryOptions);

             string url = _validateAccessBuilder.Build($"repositories/{repo}/validate", queryOptions);
             await _httpFacade.PostAsync(url, body, cancellationToken).
                ConfigureAwait(false);
        }



        /// <summary>
        ///  GetAppDetailsAsync returns application details by given path
        /// </summary>
        /// <param name="repoURL">RepoURL is the URL to the repository (Git or Helm) that contains the application manifests</param>
        /// <param name="request">Get app details request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<RepositoryRepoAppDetails> GetAppDetailsAsync(string repoURL, AppDetailsRequest request, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(repoURL, nameof(repoURL));
            Guard.NotNull(request, nameof(request));

           return await _httpFacade.PostAsync<RepositoryRepoAppDetails>($"repositories/{repoURL}/appdetails", request, cancellationToken).
                ConfigureAwait(false);
        }
    }
}
