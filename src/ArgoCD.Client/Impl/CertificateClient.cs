using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Internal.Builders;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models;
using ArgoCD.Client.Models.Certificate.Reponses;
using ArgoCD.Client.Models.Certificate.Requests;

namespace ArgoCD.Client.Impl
{
    public class CertificateClient : ICertificateClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;
        private readonly UpsertBuilder _upsertBuilder;
        private readonly CertificateQueryBuilder _certificateQueryBuilder;

        internal CertificateClient(IArgoCDHttpFacade httpFacade,
            UpsertBuilder upsertBuilder,
            CertificateQueryBuilder certificateQueryBuilder)
        {
            _httpFacade = httpFacade;
            _upsertBuilder = upsertBuilder;
            _certificateQueryBuilder = certificateQueryBuilder;
        }


        /// <summary>
        ///Creates repository certificates on the server
        /// </summary>
        /// <param name="request">Create repository certificate request</param>
        /// <param name="options">Create options <see cref="UpsertOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<RepositoryCertificateList> CreateRepositoryCertificateAsync(CreateRepositoryCertificateRequest request, Action<UpsertOptions> options, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(request, nameof(request));

            var queryOptions = new UpsertOptions();
            options?.Invoke(queryOptions);

            string url = _upsertBuilder.Build("certificates", queryOptions);
            return await _httpFacade.PostAsync<RepositoryCertificateList>(url, request, cancellationToken).
                ConfigureAwait(false);

        }

        /// <summary>
        /// Delete the certificates that match the RepositoryCertificateQuery
        /// </summary>
        /// <param name="options">Delete options <see cref="CertificateQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<RepositoryCertificateList> DeleteRepositoryCertificateAsync(Action<CertificateQueryOptions> options, CancellationToken cancellationToken = default)
        {
            var queryOptions = new CertificateQueryOptions();
            options?.Invoke(queryOptions);

            string url = _certificateQueryBuilder.Build("certificates", queryOptions);
            return await _httpFacade.DeleteAsync<RepositoryCertificateList>(url, cancellationToken).
                ConfigureAwait(false);
        }

        /// <summary>
        /// List all available repository certificates
        /// </summary>
        /// <param name="options">Query options <see cref="CertificateQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<RepositoryCertificateList> GetListAsync(Action<CertificateQueryOptions> options, CancellationToken cancellationToken = default)
        {
            var queryOptions = new CertificateQueryOptions();
            options?.Invoke(queryOptions);

            string url = _certificateQueryBuilder.Build("certificates", queryOptions);
            return await _httpFacade.GetAsync<RepositoryCertificateList>(url, cancellationToken).
                ConfigureAwait(false);
        }
    }
}
