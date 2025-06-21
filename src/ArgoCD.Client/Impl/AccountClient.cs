using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Account.Requests;
using ArgoCD.Client.Models.Account.Responses;
using static System.Collections.Specialized.BitVector32;

namespace ArgoCD.Client.Impl
{
    public class AccountClient : IAccountClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;

        internal AccountClient(IArgoCDHttpFacade httpFacade) => _httpFacade = httpFacade;


        /// <summary>
        /// CanI checks if the current account has permission to perform an action
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<AccountCanI> CheckAccountPermissionAsync(string resource, string action, string subresource, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(resource, nameof(resource));
            Guard.NotEmpty(action, nameof(action));
            Guard.NotEmpty(subresource, nameof(subresource));

           return await _httpFacade.GetAsync<AccountCanI>($"account/can-i/{resource}/{action}/{subresource}", cancellationToken).
            ConfigureAwait(false);
        }

        /// <summary>
        /// CreateToken creates a token
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<CreateAccountToken> CreateAccountAsync(CreateAccountTokenRequest request, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(request, nameof(request));
            return await _httpFacade.PostAsync<CreateAccountToken>($"account/{request.Name}/token", request, cancellationToken).
                ConfigureAwait(false);
        }

        /// <summary>
        /// DeleteToken deletes a token
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task DeleteAccountAsync(string name, string id, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            Guard.NotEmpty(id, nameof(id));
              await _httpFacade.DeleteAsync($"account/{name}/token/{id}", cancellationToken).
            ConfigureAwait(false);

        }


        /// <summary>
        /// GetAccount returns an account
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<Account> GetAccountAsync(string name, CancellationToken cancellationToken = default)
        {
            Guard.NotEmpty(name, nameof(name));
            return await _httpFacade.GetAsync<Account>($"account/{name}", cancellationToken).
            ConfigureAwait(false);
        }

        /// <summary>
        /// ListAccounts returns the list of accounts
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<AccountList> GetAccountListAsync(CancellationToken cancellationToken = default) =>
            await _httpFacade.GetAsync<AccountList>("account",cancellationToken).
            ConfigureAwait(false);

        /// <summary>
        /// UpdatePassword updates an account's password to a new value
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task UpdateAccountPasswordAsync(UpdateAccountPasswordRequest request, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(request, nameof(request));
            await _httpFacade.PutAsync("account/password", request, cancellationToken).
                ConfigureAwait(false);
        }
    }
}
