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
using ArgoCD.Client.Models.Project.Responses;
using ArgoCD.Client.Internal.Builders;
using ArgoCD.Client.Models.ApplicationSet.Reponses;

namespace ArgoCD.Client
{
    public interface IApplicationClient
    {
        /// <summary>
        ///  returns list of applications
        /// </summary>
        /// <param name="options">Get options <see cref="ApplicationListQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1ApplicationList> GetListAsync(Action<ApplicationListQueryOptions> options = null, CancellationToken cancellationToken = default);

        /// <summary>
        ///  returns an applicationset by name
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1Application> GetAsync(string name, Action<ApplicationQueryOptions> options, CancellationToken cancellationToken = default);



        /// <summary>
        ///  creates an application
        /// </summary>
        /// <param name="request">Create application request</param>
        /// <param name="options">Create options <see cref="CreateOrUpdateApplicationOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1Application> CreateApplicationAsync(CreateApplicationRequest request, Action<CreateOrUpdateApplicationOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        ///  updates an application
        /// </summary>
        /// <param name="request">Update application request</param>
        /// <param name="options">Update options <see cref="CreateOrUpdateApplicationOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1Application> UpdateApplicationAsync(UpdateApplicationRequest request, Action<CreateOrUpdateApplicationOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        /// patch an application
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="request">PatchApplicationRequest is a request to patch an application</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1Application> PatchApplicationAsync(string name, PatchApplicationRequest request , CancellationToken cancellationToken = default);


        /// <summary>
        ///  deletes an application
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">delete options <see cref="DeleteApplicationOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task DeleteApplicationAsync(string name, Action<DeleteApplicationOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        ///  returns application manifests using provided files to generate them
        /// </summary>
        /// <param name="request">Get manifests with files request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<RepositoryManifest> GetManifestsWithFilesAsync(ApplicationManifestWithFilesRequest request, CancellationToken cancellationToken = default);


        /// <summary>
        /// returns list of managed resources
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ResourcesQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ApplicationManagedResources> GetManagedResourcesAsync(string name, Action<ResourcesQueryOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        /// returns resource tree
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ResourcesQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1ApplicationTree> GetResourceTreeAsync(string name, Action<ResourcesQueryOptions> options = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// returns a list of event resources
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationEventQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1EventList> GetApplicationEventsAsync(string name, Action<ApplicationEventQueryOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        ///  returns the list of all application deep links
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationLinksQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ApplicationLinks> GetApplicationLinksAsync(string name, Action<ApplicationLinksQueryOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        ///  returns stream of log entries for the specified pod. Pod
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationLogQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ApplicationLogEntryStream> GetApplicationLogsAsync(string name, Action<ApplicationLogQueryOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        ///  returns stream of log entries for the specified pod. Pod
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationManifestsQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<RepositoryManifest> GetApplicationManifestsAsync(string name, Action<ApplicationManifestsQueryOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        /// terminates the currently running operation
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Terminate options <see cref="TerminateOperationOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task TerminateOperationAsync(string name, Action<TerminateOperationOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        /// returns stream of log entries for the specified pod. Pod
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationLogQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ApplicationLogEntryStream> GetPodLogsAsync(string name, Action<ApplicationLogQueryOptions> options, CancellationToken cancellationToken = default);


        /// <summary>
        /// returns single application resource
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationResourceQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ApplicationResource> GetResourceAsync(string name, Action<ApplicationResourceQueryOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        /// patch single application resource
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Create options <see cref="CreateApplicationResourceOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ApplicationResource> CreateResourceAsync(string name, string resourceData, Action<CreateApplicationResourceOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        /// deletes a single application resource
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Delete options <see cref="DeleteApplicationResourceOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task DeleteResourceAsync(string name, Action<DeleteApplicationResourceOptions> options = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// returns list of resource actions
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationResourceQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ResourceActionsList> GetResourceActionListAsync(string name, Action<ApplicationResourceQueryOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        /// run resource action
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Run options <see cref="ApplicationResourceQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task RunResourceActionAsync(string name, string actionData,Action<ApplicationResourceQueryOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        /// returns the list of all resource deep links
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ApplicationResourceQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ApplicationLinks> GetResourceListAsync(string name, Action<ApplicationResourceQueryOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        /// Get the chart metadata (description, maintainers, home) for a specific revision of the application
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="revision">the revision of the app</param>
        /// <param name="options">Get options <see cref="ApplicationDetailsQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1ChartDetails> GetChartDetailsAsync(string name, string revision, Action<ApplicationDetailsQueryOptions> options = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the meta-data (author, date, tags, message) for a specific revision of the application
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="revision">the revision of the app</param>
        /// <param name="options">Get options <see cref="ApplicationDetailsQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1RevisionMetadata> GetMetaDataAsync(string name, string revision, Action<ApplicationDetailsQueryOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        /// rollback syncs an application to its target state
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="request">Rollback application request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1Application> RollbackSyncAsync(string name, RollbackApplicationRequest request, CancellationToken cancellationToken = default);


        /// <summary>
        /// updates an application spec
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="request">update  application spec request</param>
        /// <param name="options">update application spec options <see cref="UpdateApplicationSpecOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1ApplicationSpec> UpdateSpecAsync(string name, UpdateApplicationSpecRequest request, Action<UpdateApplicationSpecOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        ///  syncs an application to its target state
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="request">sync  application  request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1Application> SyncAsync(string name, ApplicationSyncRequest request, CancellationToken cancellationToken = default);


        /// <summary>
        ///  returns sync windows of the application
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">get sync application options <see cref="ApplicationDetailsQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ApplicationSyncWindows> GetSyncWindowsAsync(string name,Action<ApplicationDetailsQueryOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        ///  returns stream of application change events
        /// </summary>
        /// <param name="options">watch application options <see cref="ApplicationWatchQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1ApplicationEventStream> WatchEventAsync(Action<ApplicationWatchQueryOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        ///  returns stream of application resource tree
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">watch application options <see cref="ResourcesQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1ApplicationTreeStream> WatchResourceAsync(string name, Action<ResourcesQueryOptions> options = null, CancellationToken cancellationToken = default);
    }
}
