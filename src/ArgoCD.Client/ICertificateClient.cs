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
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Models.Certificate.Reponses;
using ArgoCD.Client.Models.Certificate.Requests;
using ArgoCD.Client.Models;

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
        /// <param name="options">Create options <see cref="UpsertOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<RepositoryCertificateList> CreateRepositoryCertificateAsync(CreateRepositoryCertificateRequest request, Action<UpsertOptions> options, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete the certificates that match the RepositoryCertificateQuery
        /// </summary>
        /// <param name="options">Delete options <see cref="DeleteCertificateOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<RepositoryCertificateList> DeleteRepositoryCertificateAsync(Action<DeleteCertificateOptions> options, CancellationToken cancellationToken = default);
    }
}
