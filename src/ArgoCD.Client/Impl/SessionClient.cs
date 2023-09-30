using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArgoCD.Client.Models.Session.Requests;
using ArgoCD.Client.Models.Session.Responses;

namespace ArgoCD.Client.Impl
{
    public class SessionClient:ISessionClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;

        internal SessionClient(IArgoCDHttpFacade httpFacade) => _httpFacade = httpFacade;


        /// <summary>
        /// Get the current user's info
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<UserInfo> GetCurrentUserInfoAsync(CancellationToken cancellationToken = default) =>
              await _httpFacade.GetAsync<UserInfo>("session/userinfo",cancellationToken).ConfigureAwait(false);


        /// <summary>
        /// Create a new JWT for authentication and set a cookie if using HTTP
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
       public async Task<Session> CreateSessionAsync(CreateSessionRequest request, CancellationToken cancellationToken = default)=>
            await  _httpFacade.PostAsync<Session>("session", request, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Delete an existing JWT cookie if using HTTP
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<Session> DeleteCurrentSessionAsync(CancellationToken cancellationToken = default) =>
             await _httpFacade.DeleteAsync<Session>("session", cancellationToken).ConfigureAwait(false);

    }
}
