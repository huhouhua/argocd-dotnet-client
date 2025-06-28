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
using ArgoCD.Client.Models.Account.Requests;
using ArgoCD.Client.Models.Account.Responses;

namespace ArgoCD.Client
{
    public interface IAccountClient
    {
        /// <summary>
        /// ListAccounts returns the list of accounts
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<AccountList> GetAccountListAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// GetAccount returns an account
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<Account> GetAccountAsync(string name, CancellationToken cancellationToken = default);


        /// <summary>
        /// CanI checks if the current account has permission to perform an action
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<AccountCanI> CheckAccountPermissionAsync(string resource, string action, string subresource, CancellationToken cancellationToken = default);

        /// <summary>
        /// UpdatePassword updates an account's password to a new value
        /// </summary>
        /// <param name="request">Update account password request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task UpdateAccountPasswordAsync(UpdateAccountPasswordRequest request, CancellationToken cancellationToken = default);


        /// <summary>
        /// CreateToken creates a token
        /// </summary>
        /// <param name="request">Create account token request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<CreateAccountToken> CreateAccountAsync(CreateAccountTokenRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// DeleteToken deletes a token
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task DeleteAccountAsync(string name, string id, CancellationToken cancellationToken = default);

    }
}
