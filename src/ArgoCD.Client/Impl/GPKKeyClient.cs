using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Internal.Queries;
using ArgoCD.Client.Models.GPKKey.Responses;
using ArgoCD.Client.Models.GPKKey.Requests;

namespace ArgoCD.Client.Impl
{
    public class GPKKeyClient : IGPKKeyClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;
        private readonly GPKKeyCreateBuilder _gPKKeyCreateBuilder;
        private readonly GPKKeyDeleteBuilder _gPKKeyDeleteBuilder;

        internal GPKKeyClient(IArgoCDHttpFacade httpFacade,
            GPKKeyCreateBuilder gPKKeyCreateBuilder,
            GPKKeyDeleteBuilder gPKKeyDeleteBuilder)
        {
            _httpFacade = httpFacade;
            _gPKKeyCreateBuilder = gPKKeyCreateBuilder;
            _gPKKeyDeleteBuilder = gPKKeyDeleteBuilder;
        }


        /// <summary>
        /// List all available repository certificates
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<GnuPGPublicKeyList> GetListAsync(CancellationToken cancellationToken = default) =>
             await _httpFacade.GetAsync<GnuPGPublicKeyList>("gpgkeys", cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get information about specified GPG public key from the server
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <param name="keyID">The GPG key ID to query for </param>
        /// <returns></returns>
        public async Task<V1alpha1GnuPGPublicKey> GetAsync(string keyID, CancellationToken cancellationToken = default) =>
            await _httpFacade.GetAsync<V1alpha1GnuPGPublicKey>($"gpgkeys/{keyID}", cancellationToken).ConfigureAwait(false);


        /// <summary>
        /// Create one or more GPG public keys in the server's configuration
        /// </summary>
        /// <param name="request">Create GPKKey request</param>
        /// <param name="options">Create options <see cref="CreateGPKKeyOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<GnuPGPublicKey> CreateGPKKeyAsync(CreateGPGKeyRequest request, Action<CreateGPKKeyOptions> options, CancellationToken cancellationToken = default)
        {
            var queryOptions = new CreateGPKKeyOptions();
            options?.Invoke(queryOptions);

            string url = _gPKKeyCreateBuilder.Build("gpgkeys", queryOptions);
            return await _httpFacade.PostAsync<GnuPGPublicKey>(url, request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete specified GPG public key from the server's configuration
        /// </summary>
        /// <param name="options">Delete options <see cref="DeleteGPGKeyOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task DeleteGPKKeyAsync(Action<DeleteGPGKeyOptions> options, CancellationToken cancellationToken = default)
        {
            var queryOptions = new DeleteGPGKeyOptions();
            options?.Invoke(queryOptions);

            string url = _gPKKeyDeleteBuilder.Build("gpgkeys", queryOptions);
            await _httpFacade.DeleteAsync(url, cancellationToken).ConfigureAwait(false);

        }
    }
}

