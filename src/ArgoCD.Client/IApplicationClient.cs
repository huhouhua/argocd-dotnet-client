using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Models.Application.Reponses;
using ArgoCD.Client.Models.Application.Requests;

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
        /// Get returns an applicationset by name
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
        /// <param name="options">Get options <see cref="ManagedResourcesQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ApplicationManagedResources> GetManagedResourcesAsync(string name, Action<ManagedResourcesQueryOptions> options = null, CancellationToken cancellationToken = default);


        /// <summary>
        /// returns resource tree
        /// </summary>
        /// <param name="name">the application's name</param>
        /// <param name="options">Get options <see cref="ManagedResourcesQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1ApplicationTree> GetResourceTreeAsync(string name, Action<ManagedResourcesQueryOptions> options = null, CancellationToken cancellationToken = default);





    }
}
