using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Internal.Builders;
using ArgoCD.Client.Models.GPKKey.Responses;
using ArgoCD.Client.Models.GPKKey.Requests;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Models;
using ArgoCD.Client.Internal.Utilities;

namespace ArgoCD.Client.Impl
{
    public class GPGKeyClient : IGPGKeyClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;
        private readonly UpsertBuilder _upsertBuilder;
        private readonly GPGKeyDeleteBuilder _gpgKeyDeleteBuilder;
        private readonly GPGListQueryBuilder _gpgListQueryBuilder;

        internal GPGKeyClient(IArgoCDHttpFacade httpFacade,
               UpsertBuilder upsertBuilder,
                GPGKeyDeleteBuilder gpgKeyDeleteBuilder,
                    GPGListQueryBuilder  gpgListQueryBuilder)
        {
            _httpFacade = httpFacade;
            _upsertBuilder = upsertBuilder;
            _gpgKeyDeleteBuilder = gpgKeyDeleteBuilder;
            _gpgListQueryBuilder = gpgListQueryBuilder;
        }

        /// <summary>
        /// List all available repository certificates
        /// </summary>
        /// <param name="options">List GPG key options <see cref="DeleteGPGKeyOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<GnuPGPublicKeyList> GetListAsync(Action<GPGListQueryOptions> options,
            CancellationToken cancellationToken = default)
        {
            var queryOptions = new GPGListQueryOptions();
            options?.Invoke(queryOptions);

            string url = _gpgListQueryBuilder.Build("gpgkeys", queryOptions);
            return  await _httpFacade.GetAsync<GnuPGPublicKeyList>(url, cancellationToken).
                ConfigureAwait(false);
        }

        /// <summary>
        /// Get information about specified GPG public key from the server
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <param name="keyID">The GPG key ID to query for </param>
        /// <returns></returns>
        public async Task<V1alpha1GnuPGPublicKey> GetAsync(string keyID, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(keyID, nameof(keyID));
           return await _httpFacade.GetAsync<V1alpha1GnuPGPublicKey>($"gpgkeys/{keyID}", cancellationToken).
            ConfigureAwait(false);
        }


        /// <summary>
        /// Create one or more GPG public keys in the server's configuration
        /// </summary>
        /// <param name="request">Create GPKKey request</param>
        /// <param name="options">Create options <see cref="UpsertOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<GnuPGPublicKey> CreateGPKKeyAsync(CreateGPGKeyRequest request, Action<UpsertOptions> options, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(request, nameof(request));

            var upsertOptions = new UpsertOptions();
            options?.Invoke(upsertOptions);

            string url = _upsertBuilder.Build("gpgkeys", upsertOptions);
            return await _httpFacade.PostAsync<GnuPGPublicKey>(url, request, cancellationToken).
                ConfigureAwait(false);
        }

        /// <summary>
        /// Delete specified GPG public key from the server's configuration
        /// </summary>
        /// <param name="options">Delete options <see cref="DeleteGPGKeyOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task DeleteGPKKeyAsync(Action<DeleteGPGKeyOptions> options, CancellationToken cancellationToken = default)
        {
            var deleteOptions = new DeleteGPGKeyOptions();
            options?.Invoke(deleteOptions);

            string url = _gpgKeyDeleteBuilder.Build("gpgkeys", deleteOptions);
            await _httpFacade.DeleteAsync(url, cancellationToken).
                ConfigureAwait(false);

        }
    }
}

