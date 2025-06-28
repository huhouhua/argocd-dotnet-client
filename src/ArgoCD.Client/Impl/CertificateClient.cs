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
        private readonly CertificateDeleteBuilder _certificateDeleteBuilder;
        internal CertificateClient(IArgoCDHttpFacade httpFacade,
            UpsertBuilder upsertBuilder,
            CertificateQueryBuilder certificateQueryBuilder,
            CertificateDeleteBuilder certificateDeleteBuilder)
        {
            _httpFacade = httpFacade;
            _upsertBuilder = upsertBuilder;
            _certificateQueryBuilder = certificateQueryBuilder;
            _certificateDeleteBuilder = certificateDeleteBuilder;
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

            var upsertOptions = new UpsertOptions();
            options?.Invoke(upsertOptions);

            string url = _upsertBuilder.Build("certificates", upsertOptions);
            return await _httpFacade.PostAsync<RepositoryCertificateList>(url, request, cancellationToken).
                ConfigureAwait(false);

        }

        /// <summary>
        /// Delete the certificates that match the RepositoryCertificateQuery
        /// </summary>
        /// <param name="options">Delete options <see cref="DeleteCertificateOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<RepositoryCertificateList> DeleteRepositoryCertificateAsync(Action<DeleteCertificateOptions> options, CancellationToken cancellationToken = default)
        {
            var deleteOptions = new DeleteCertificateOptions();
            options?.Invoke(deleteOptions);

            string url = _certificateDeleteBuilder.Build("certificates", deleteOptions);
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
