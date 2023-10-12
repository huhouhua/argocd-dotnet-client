using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Models.Session.Requests;
using ArgoCD.Client.Models.Session.Responses;
using ArgoCD.Client.Models.GPKKey.Responses;
using ArgoCD.Client.Models.GPKKey.Requests;
using ArgoCD.Client.Internal.Builders;
using ArgoCD.Client.Models;

namespace ArgoCD.Client
{
    public interface IGPKKeyClient
    {
        /// <summary>
        /// List all available repository certificates
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<GnuPGPublicKeyList> GetListAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get information about specified GPG public key from the server
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <param name="keyID">The GPG key ID to query for </param>
        /// <returns></returns>
        Task<V1alpha1GnuPGPublicKey> GetAsync(string keyID, CancellationToken cancellationToken = default);


        /// <summary>
        /// Create one or more GPG public keys in the server's configuration
        /// </summary>
        /// <param name="request">Create GPKKey request</param>
        /// <param name="options">Create options <see cref="UpsertOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<GnuPGPublicKey> CreateGPKKeyAsync(CreateGPGKeyRequest request, Action<UpsertOptions> options, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete specified GPG public key from the server's configuration
        /// </summary>
        /// <param name="options">Delete options <see cref="DeleteGPGKeyOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task DeleteGPKKeyAsync(Action<DeleteGPGKeyOptions> options, CancellationToken cancellationToken = default);

    }
}
