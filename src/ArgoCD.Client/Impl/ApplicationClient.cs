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
using ArgoCD.Client.Models.Application.Reponses;
using ArgoCD.Client.Models.Application.Requests;
using ArgoCD.Client.Internal.Builders;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Internal.Utilities;
using System.Xml.Linq;
using ArgoCD.Client.Models.Project.Responses;
using Microsoft.Extensions.Options;
using ArgoCD.Client.Models.ApplicationSet.Reponses;

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
        private readonly ApplicationEventQueryBuilder _applicationEventQueryBuilder;
        private readonly ApplicationLinksQueryBuilder _applicationLinksQueryBuilder;
        private readonly ApplicationLogQueryBuilder _applicationLogQueryBuilder;
        private readonly ApplicationManifestsQueryBuilder _applicationManifestsQueryBuilder;
        private readonly TerminateOperationBuilder _terminateOperationBuilder;
        private readonly ApplicationResourceQueryBuilder _applicationResourceQueryBuilder;
        private readonly ApplicationResourceCreateBuilder _applicationResourceCreateBuilder;
        private readonly ApplicationResourceDeleteBuilder _applicationResourceDeleteBuilder;
        private readonly ApplicationDetailsQueryBuilder _applicationDetailsQueryBuilder;
        private readonly ApplicationUpdateSpecBuilder _applicationUpdateSpecBuilder;
        private readonly ApplicationWatchQueryBuilder _applicationWatchQueryBuilder;


        internal ApplicationClient(IArgoCDHttpFacade httpFacade,
            ApplicationListQueryBuilder applicationListQueryBuilder,
            ApplicationQueryBuilder applicationQueryBuilder,
            ApplicationCreateOrUpdateBuilder applicationCreateOrUpdateBuilder,
            ApplicationDeleteBuilder applicationDeleteBuilder,
            ResourcesQueryBuilder resourcesQueryBuilder,
            ApplicationEventQueryBuilder applicationEventQueryBuilder,
            ApplicationLinksQueryBuilder applicationLinksQueryBuilder,
            ApplicationLogQueryBuilder applicationLogQueryBuilder,
            ApplicationManifestsQueryBuilder applicationManifestsQueryBuilder,
            TerminateOperationBuilder terminateOperationBuilder,
            ApplicationResourceQueryBuilder applicationResourceQueryBuilder,
            ApplicationResourceCreateBuilder applicationResourceCreateBuilder,
            ApplicationResourceDeleteBuilder applicationResourceDeleteBuilder,
            ApplicationDetailsQueryBuilder applicationDetailsQueryBuilder,
            ApplicationUpdateSpecBuilder applicationUpdateSpecBuilder,
            ApplicationWatchQueryBuilder applicationWatchQueryBuilder)
        {
            _httpFacade = httpFacade;
            _applicationListQueryBuilder = applicationListQueryBuilder;
            _applicationQueryBuilder = applicationQueryBuilder;
            _applicationCreateOrUpdateBuilder = applicationCreateOrUpdateBuilder;
            _applicationDeleteBuilder = applicationDeleteBuilder;
            _resourcesQueryBuilder = resourcesQueryBuilder;
            _applicationEventQueryBuilder = applicationEventQueryBuilder;
            _applicationLinksQueryBuilder = applicationLinksQueryBuilder;
            _applicationLogQueryBuilder = applicationLogQueryBuilder;
            _applicationManifestsQueryBuilder = applicationManifestsQueryBuilder;
            _applicationResourceDeleteBuilder = applicationResourceDeleteBuilder;
            _terminateOperationBuilder = terminateOperationBuilder;
            _applicationResourceQueryBuilder = applicationResourceQueryBuilder;
            _applicationResourceCreateBuilder = applicationResourceCreateBuilder;
            _applicationDetailsQueryBuilder = applicationDetailsQueryBuilder;
            _applicationUpdateSpecBuilder = applicationUpdateSpecBuilder;
            _applicationWatchQueryBuilder = applicationWatchQueryBuilder;
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



        /// <summary>
        /// returns a list of event resources
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationEventQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1EventList> GetApplicationEventsAsync(string name, Action<ApplicationEventQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            var queryOptions = new ApplicationEventQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationEventQueryBuilder.Build($"applications/{name}/events", queryOptions);
            return await _httpFacade.GetAsync<V1EventList>(url, cancellationToken).
                ConfigureAwait(false);

        }

        /// <summary>
        ///  returns the list of all application deep links
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationLinksQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ApplicationLinks> GetApplicationLinksAsync(string name, Action<ApplicationLinksQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            var queryOptions = new ApplicationLinksQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationLinksQueryBuilder.Build($"applications/{name}/links", queryOptions);
            return await _httpFacade.GetAsync<ApplicationLinks>(url, cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        ///  returns stream of log entries for the specified pod. Pod
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationLogQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ApplicationLogEntryStream> GetApplicationLogsAsync(string name, Action<ApplicationLogQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            var queryOptions = new ApplicationLogQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationLogQueryBuilder.Build($"applications/{name}/logs", queryOptions);
            return await _httpFacade.GetAsync<ApplicationLogEntryStream>(url, cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        ///  returns stream of log entries for the specified pod. Pod
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationManifestsQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<RepositoryManifest> GetApplicationManifestsAsync(string name, Action<ApplicationManifestsQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            var queryOptions = new ApplicationManifestsQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationManifestsQueryBuilder.Build($"applications/{name}/manifests", queryOptions);
            return await _httpFacade.GetAsync<RepositoryManifest>(url, cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        /// terminates the currently running operation
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Terminate options <see cref="TerminateOperationOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task TerminateOperationAsync(string name, Action<TerminateOperationOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            var queryOptions = new TerminateOperationOptions();
            options?.Invoke(queryOptions);

            string url = _terminateOperationBuilder.Build($"applications/{name}/operation", queryOptions);
             await _httpFacade.DeleteAsync(url, cancellationToken).
                ConfigureAwait(false);

        }


        /// <summary>
        /// returns stream of log entries for the specified pod. Pod
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationLogQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ApplicationLogEntryStream> GetPodLogsAsync(string name, Action<ApplicationLogQueryOptions> options, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            Guard.NotNull(options, nameof(options));

            var queryOptions = new ApplicationLogQueryOptions();
            options.Invoke(queryOptions);

            Guard.NotEmpty(queryOptions.PodName, nameof(queryOptions.PodName));

            string url = _applicationLogQueryBuilder.Build($"applications/{name}/pods/{queryOptions.PodName}/logs", queryOptions);
           return await _httpFacade.GetAsync<ApplicationLogEntryStream>(url, cancellationToken).
               ConfigureAwait(false);
        }


        /// <summary>
        /// returns single application resource
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationResourceQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ApplicationResource> GetResourceAsync(string name, Action<ApplicationResourceQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            var queryOptions = new ApplicationResourceQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationResourceQueryBuilder.Build($"applications/{name}/resource", queryOptions);
            return await _httpFacade.GetAsync<ApplicationResource>(url, cancellationToken).
                ConfigureAwait(false);

        }


        /// <summary>
        /// patch single application resource
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Create options <see cref="CreateApplicationResourceOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ApplicationResource> CreateResourceAsync(string name, string resourceData, Action<CreateApplicationResourceOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            Guard.NotEmpty(resourceData, nameof(resourceData));
            var queryOptions = new CreateApplicationResourceOptions();
            options?.Invoke(queryOptions);

            string url = _applicationResourceCreateBuilder.Build($"applications/{name}/resource", queryOptions);
            return await _httpFacade.PostAsync<ApplicationResource>(url, resourceData, cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        /// deletes a single application resource
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Delete options <see cref="DeleteApplicationResourceOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task DeleteResourceAsync(string name, Action<DeleteApplicationResourceOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            var queryOptions = new DeleteApplicationResourceOptions();
            options?.Invoke(queryOptions);

            string url = _applicationResourceDeleteBuilder.Build($"applications/{name}/resource", queryOptions);
             await _httpFacade.DeleteAsync(url, cancellationToken).
                ConfigureAwait(false);
        }

        /// <summary>
        /// returns list of resource actions
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationResourceQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ResourceActionsList> GetResourceActionListAsync(string name, Action<ApplicationResourceQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            var queryOptions = new ApplicationResourceQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationResourceQueryBuilder.Build($"applications/{name}/resource/actions", queryOptions);
          return  await _httpFacade.GetAsync<ResourceActionsList>(url, cancellationToken).
               ConfigureAwait(false);

        }


        /// <summary>
        /// run resource action
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Run options <see cref="ApplicationResourceQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task RunResourceActionAsync(string name, string actionData, Action<ApplicationResourceQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            Guard.NotEmpty(actionData, nameof(actionData));
            var queryOptions = new ApplicationResourceQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationResourceQueryBuilder.Build($"applications/{name}/resource/actions", queryOptions);
             await _httpFacade.PostAsync(url, actionData, cancellationToken).
                 ConfigureAwait(false);
        }


        /// <summary>
        /// returns the list of all resource deep links
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationResourceQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ApplicationLinks> GetResourceListAsync(string name, Action<ApplicationResourceQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            var queryOptions = new ApplicationResourceQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationResourceQueryBuilder.Build($"applications/{name}/resource/links", queryOptions);
           return await _httpFacade.GetAsync< ApplicationLinks >(url, cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        /// Get the chart metadata (description, maintainers, home) for a specific revision of the application
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="revision">the revision of the app</param>
        /// <param name="options">Get options <see cref="ApplicationDetailsQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1ChartDetails> GetChartDetailsAsync(string name, string revision, Action<ApplicationDetailsQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            Guard.NotEmpty(revision, nameof(revision));
            var queryOptions = new ApplicationDetailsQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationDetailsQueryBuilder.Build($"applications/{name}/revisions/{revision}/chartdetails", queryOptions);
            return await _httpFacade.GetAsync<V1alpha1ChartDetails>(url, cancellationToken).
                 ConfigureAwait(false);
        }

        /// <summary>
        /// Get the meta-data (author, date, tags, message) for a specific revision of the application
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="revision">the revision of the app</param>
        /// <param name="options">Get options <see cref="ApplicationDetailsQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1RevisionMetadata> GetMetaDataAsync(string name, string revision, Action<ApplicationDetailsQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            Guard.NotEmpty(revision, nameof(revision));
            var queryOptions = new ApplicationDetailsQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationDetailsQueryBuilder.Build($"applications/{name}/revisions/{revision}/metadata", queryOptions);
            return await _httpFacade.GetAsync<V1alpha1RevisionMetadata>(url, cancellationToken).
                 ConfigureAwait(false);
        }


        /// <summary>
        /// rollback syncs an application to its target state
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="request">Rollback application request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1Application> RollbackSyncAsync(string name, RollbackApplicationRequest request, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            Guard.NotNull(request, nameof(request));
            return await _httpFacade.PostAsync<V1alpha1Application>($"applications/{name}/rollback", request, cancellationToken).
                 ConfigureAwait(false);

        }


        /// <summary>
        /// updates an application spec
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="request">update  application spec request</param>
        /// <param name="options">update application spec options <see cref="UpdateApplicationSpecOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1ApplicationSpec> UpdateSpecAsync(string name, UpdateApplicationSpecRequest request, Action<UpdateApplicationSpecOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            Guard.NotNull(request, nameof(request));
            Guard.NotNull(request.ApplicationSpec, nameof(request.ApplicationSpec));
            var queryOptions = new UpdateApplicationSpecOptions();
            options?.Invoke(queryOptions);

             string url = _applicationUpdateSpecBuilder.Build($"applications/{name}/spec", queryOptions);
            return await _httpFacade.PutAsync<V1alpha1ApplicationSpec>(url, request.ApplicationSpec, cancellationToken).
                 ConfigureAwait(false);

        }


        /// <summary>
        ///  syncs an application to its target state
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="request">sync  application  request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1Application> SyncAsync(string name, ApplicationSyncRequest request,  CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            Guard.NotNull(request, nameof(request));
            return await _httpFacade.PostAsync<V1alpha1Application>($"applications/{name}/sync", request, cancellationToken).
                 ConfigureAwait(false);

        }


        /// <summary>
        ///  returns sync windows of the application
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">get sync application options <see cref="ApplicationDetailsQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ApplicationSyncWindows> GetSyncWindowsAsync(string name, Action<ApplicationDetailsQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            var queryOptions = new ApplicationDetailsQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationDetailsQueryBuilder.Build($"applications/{name}/syncwindows", queryOptions);
            return await _httpFacade.GetAsync<ApplicationSyncWindows>(url, cancellationToken).
                 ConfigureAwait(false);
        }


        /// <summary>
        ///  returns stream of application change events
        /// </summary>
        /// <param name="options">watch application options <see cref="ApplicationWatchQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1ApplicationEventStream> WatchEventAsync(Action<ApplicationWatchQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            var queryOptions = new ApplicationWatchQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationWatchQueryBuilder.Build("stream/applications", queryOptions);
            return await _httpFacade.GetAsync<V1alpha1ApplicationEventStream>(url, cancellationToken).
                 ConfigureAwait(false);

        }


        /// <summary>
        ///  returns stream of application resource tree
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">watch application options <see cref="ResourcesQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1ApplicationTreeStream> WatchResourceAsync(string name, Action<ResourcesQueryOptions> options = null, CancellationToken cancellationToken = default)
        {
            var queryOptions = new ResourcesQueryOptions();
            options?.Invoke(queryOptions);

            string url = _resourcesQueryBuilder.Build($"stream/applications/{name}/resource-tree", queryOptions);
            return await _httpFacade.GetAsync<V1alpha1ApplicationTreeStream>(url, cancellationToken).
                 ConfigureAwait(false);
        }
    }
}
