using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Models.Application.Reponses;
using ArgoCD.Client.Models.Application.Requests;
using ArgoCD.Client.Internal.Builders;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Internal.Utilities;
using System.Xml.Linq;

namespace ArgoCD.Client.Impl
{
    public class ApplicationClient : IApplicationClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;
        private readonly ApplicationListQueryBuilder _applicationListQueryBuilder;
        private readonly ApplicationQueryBuilder _applicationQueryBuilder;
        private readonly ApplicationCreateOrUpdateBuilder _applicationCreateOrUpdateBuilder;
        private readonly ApplicationDeleteBuilder _applicationDeleteBuilder;
        private readonly ResourcesQueryBuilder _resourcesQueryBuilder;
        internal ApplicationClient(IArgoCDHttpFacade httpFacade,
            ApplicationListQueryBuilder applicationListQueryBuilder,
            ApplicationQueryBuilder applicationQueryBuilder,
            ApplicationCreateOrUpdateBuilder applicationCreateOrUpdateBuilder,
            ApplicationDeleteBuilder applicationDeleteBuilder,
            ResourcesQueryBuilder resourcesQueryBuilder)
        {
            _httpFacade = httpFacade;
            _applicationListQueryBuilder = applicationListQueryBuilder;
            _applicationQueryBuilder = applicationQueryBuilder;
            _applicationCreateOrUpdateBuilder = applicationCreateOrUpdateBuilder;
            _applicationDeleteBuilder = applicationDeleteBuilder;
            _resourcesQueryBuilder = resourcesQueryBuilder;
        }

        /// <summary>
        ///  returns list of applications
        /// </summary>
        /// <param name="options">Get options <see cref="ApplicationListQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1ApplicationList> GetListAsync(Action<ApplicationListQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            var queryOptions = new ApplicationListQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationListQueryBuilder.Build("applications", queryOptions);
            return await _httpFacade.GetAsync<V1alpha1ApplicationList>(url, cancellationToken).
                ConfigureAwait(false);
        }

        /// <summary>
        ///  returns an applicationset by name
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1Application> GetAsync(string name, Action<ApplicationQueryOptions> options, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            var queryOptions = new ApplicationQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationQueryBuilder.Build($"applications/{name}", queryOptions);
            return await _httpFacade.GetAsync<V1alpha1Application>(url, cancellationToken).
                ConfigureAwait(false);
        }



        /// <summary>
        ///  creates an application
        /// </summary>
        /// <param name="request">Create application request</param>
        /// <param name="options">Create options <see cref="CreateOrUpdateApplicationOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1Application> CreateApplicationAsync(CreateApplicationRequest request, Action<CreateOrUpdateApplicationOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(request, nameof(request));
            var queryOptions = new CreateOrUpdateApplicationOptions();
            options?.Invoke(queryOptions);

            string url = _applicationCreateOrUpdateBuilder.Build("applications", queryOptions);
            return await _httpFacade.PostAsync<V1alpha1Application>(url, cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        ///  updates an application
        /// </summary>
        /// <param name="request">Get manifests with files request</param>
        /// <param name="options">Update options <see cref="CreateOrUpdateApplicationOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1Application> UpdateApplicationAsync(UpdateApplicationRequest request, Action<CreateOrUpdateApplicationOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(request, nameof(request));
            Guard.NotEmpty(request.Name, nameof(request.Name));
            var queryOptions = new CreateOrUpdateApplicationOptions();
            options?.Invoke(queryOptions);

            string url = _applicationCreateOrUpdateBuilder.Build($"applications/{request.Name}", queryOptions);
            return await _httpFacade.PutAsync<V1alpha1Application>(url, cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        /// patch an application
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="request">PatchApplicationRequest is a request to patch an application</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1Application> PatchApplicationAsync(string name, PatchApplicationRequest request, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            Guard.NotNull(request, nameof(request));

            return await _httpFacade.PatchAsync<V1alpha1Application>($"applications/{name}", cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        ///  deletes an application
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">delete options <see cref="DeleteApplicationOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task DeleteApplicationAsync(string name, Action<DeleteApplicationOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            var queryOptions = new DeleteApplicationOptions();
            options?.Invoke(queryOptions);

            string url = _applicationDeleteBuilder.Build($"applications/{name}", queryOptions);
            await _httpFacade.DeleteAsync<V1alpha1Application>(url, cancellationToken).
               ConfigureAwait(false);

        }


        /// <summary>
        ///  returns application manifests using provided files to generate them
        /// </summary>
        /// <param name="request">Get manifests with files request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<RepositoryManifest> GetManifestsWithFilesAsync(ApplicationManifestWithFilesRequest request, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(request, nameof(request));
            return await _httpFacade.PostAsync<RepositoryManifest>("applications/manifestsWithFiles", cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        /// returns list of managed resources
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ResourcesQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ApplicationManagedResources> GetManagedResourcesAsync(string name, Action<ResourcesQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            var queryOptions = new ResourcesQueryOptions();
            options?.Invoke(queryOptions);

            string url = _resourcesQueryBuilder.Build($"applications/{name}/managed-resources", queryOptions);
            return await _httpFacade.GetAsync<ApplicationManagedResources>(url, cancellationToken).
                ConfigureAwait(false);

        }


        /// <summary>
        /// returns resource tree
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ResourcesQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1ApplicationTree> GetResourceTreeAsync(string name, Action<ResourcesQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            var queryOptions = new ResourcesQueryOptions();
            options?.Invoke(queryOptions);

            string url = _resourcesQueryBuilder.Build($"applications/{name}/resource-tree", queryOptions);
            return await _httpFacade.GetAsync<V1alpha1ApplicationTree>(url, cancellationToken).
                ConfigureAwait(false);
        }
    }
}
