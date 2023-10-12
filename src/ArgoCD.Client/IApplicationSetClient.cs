using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArgoCD.Client.Models;
using ArgoCD.Client.Models.ApplicationSet.Reponses;
using ArgoCD.Client.Models.ApplicationSet.Requests;
using ArgoCD.Client.Models.GPKKey.Responses;

namespace ArgoCD.Client
{
    public interface IApplicationSetClient
    {
        /// <summary>
        /// List returns list of applicationset
        /// </summary>
        /// <param name="options">Get options <see cref="ApplicationSetListQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1ApplicationSetList> GetListAsync(Action<ApplicationSetListQueryOptions> options, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get returns an applicationset by name
        /// </summary>
        /// <param name="name">the applicationsets's name</param>
        /// <param name="options">Get options <see cref="ApplicationSetQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1ApplicationSet> GetAsync(string name, Action<ApplicationSetQueryOptions> options, CancellationToken cancellationToken = default);


        /// <summary>
        /// Create creates an applicationset
        /// </summary>
        /// <param name="request">Create applicationset request</param>
        /// <param name="options">Create options <see cref="UpsertOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1ApplicationSet> CreateApplicationSetAsync(CreateApplicationSetRequest request, Action<UpsertOptions> options, CancellationToken cancellationToken = default);


        /// <summary>
        /// Delete deletes an application set
        /// </summary>
        /// <param name="name">the applicationsets's name</param>
        /// <param name="options">delete options <see cref="ApplicationSetQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<DeleteApplicationSetResult> DeleteAsync(string name, Action<ApplicationSetQueryOptions> options, CancellationToken cancellationToken = default);

    }
}
