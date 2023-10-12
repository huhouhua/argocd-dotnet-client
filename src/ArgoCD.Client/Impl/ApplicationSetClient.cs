using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Models.ApplicationSet.Requests;
using ArgoCD.Client.Models.ApplicationSet.Reponses;
using ArgoCD.Client.Models;
using ArgoCD.Client.Internal.Builders;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Internal.Utilities;
using System.Xml.Linq;

namespace ArgoCD.Client.Impl
{
    public class ApplicationSetClient : IApplicationSetClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;
        private readonly UpsertBuilder _upsertBuilder;
        private readonly ApplicationSetQueryBuilder _applicationSetQueryBuilder;
        private readonly ApplicationSetListQueryBuilder _applicationSetListQueryBuilder;
        internal ApplicationSetClient(IArgoCDHttpFacade httpFacade,
            UpsertBuilder upsertBuilder,
            ApplicationSetQueryBuilder applicationSetQueryBuilder,
            ApplicationSetListQueryBuilder applicationSetListQueryBuilder)
        {
            _httpFacade = httpFacade;
            _upsertBuilder = upsertBuilder;
            _applicationSetQueryBuilder = applicationSetQueryBuilder;
            _applicationSetListQueryBuilder = applicationSetListQueryBuilder;
        }

        /// <summary>
        /// List returns list of applicationset
        /// </summary>
        /// <param name="options">Get options <see cref="ApplicationSetListQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1ApplicationSetList> GetListAsync(Action<ApplicationSetListQueryOptions> options, CancellationToken cancellationToken = default)
        {
            var queryOptions = new ApplicationSetListQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationSetListQueryBuilder.Build("applicationsets", queryOptions);
            return await _httpFacade.GetAsync<V1alpha1ApplicationSetList>(url, cancellationToken).
                ConfigureAwait(false);
        }

        /// <summary>
        /// Get returns an applicationset by name
        /// </summary>
        /// <param name="name">the applicationsets's name</param>
        /// <param name="options">Get options <see cref="ApplicationSetQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1ApplicationSet> GetAsync(string name, Action<ApplicationSetQueryOptions> options, CancellationToken cancellationToken = default)
        {
            var queryOptions = new ApplicationSetQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationSetQueryBuilder.Build($"applicationsets/{name}", queryOptions);
            return await _httpFacade.GetAsync<V1alpha1ApplicationSet>(url, cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        /// Create creates an applicationset
        /// </summary>
        /// <param name="request">Create applicationset request</param>
        /// <param name="options">Create options <see cref="UpsertOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1ApplicationSet> CreateApplicationSetAsync(CreateApplicationSetRequest request, Action<UpsertOptions> options, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(request?.ApplicationSet, nameof(request));

            var queryOptions = new UpsertOptions();
            options?.Invoke(queryOptions);

            string url = _upsertBuilder.Build("applicationsets", queryOptions);
            return await _httpFacade.PostAsync<V1alpha1ApplicationSet>(url, request.ApplicationSet, cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        /// Delete deletes an application set
        /// </summary>
        /// <param name="name">the applicationsets's name</param>
        /// <param name="options">delete options <see cref="ApplicationSetQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<DeleteApplicationSetResult> DeleteAsync(string name, Action<ApplicationSetQueryOptions> options, CancellationToken cancellationToken = default)
        {
            var queryOptions = new ApplicationSetQueryOptions();
            options?.Invoke(queryOptions);

            string url = _applicationSetQueryBuilder.Build($"applicationsets/{name}", queryOptions);
            return await _httpFacade.DeleteAsync<DeleteApplicationSetResult>(url, cancellationToken).
                ConfigureAwait(false);

        }
    }
}
