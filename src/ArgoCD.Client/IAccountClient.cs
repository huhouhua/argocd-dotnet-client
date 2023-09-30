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
