using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Models.Certificate.Reponses;
using ArgoCD.Client.Models.Certificate.Requests;

namespace ArgoCD.Client
{
    public interface ICertificateClient
    {
        /// <summary>
        /// List all available repository certificates
        /// </summary>
        /// <param name="options">Query options <see cref="CertificateQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<RepositoryCertificateList> GetListAsync(Action<CertificateQueryOptions> options, CancellationToken cancellationToken = default);



        /// <summary>
        ///Creates repository certificates on the server
        /// </summary>
        /// <param name="request">Create repository certificate request</param>
        /// <param name="options">Create options <see cref="CreateCertificateOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<RepositoryCertificateList> CreateRepositoryCertificateAsync(CreateRepositoryCertificateRequest request, Action<CreateCertificateOptions> options, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete the certificates that match the RepositoryCertificateQuery
        /// </summary>
        /// <param name="options">Delete options <see cref="CertificateQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<RepositoryCertificateList> DeleteRepositoryCertificateAsync(Action<CertificateQueryOptions> options, CancellationToken cancellationToken = default);
    }
}
