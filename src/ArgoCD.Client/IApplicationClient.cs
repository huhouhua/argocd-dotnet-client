using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Models.Application.Reponses;
using ArgoCD.Client.Models.Application.Requests;
using ArgoCD.Client.Models.Project.Responses;

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
        /// <param name="request">Get manifests with files request</param>
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
    }
}
