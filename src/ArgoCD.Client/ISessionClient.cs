using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArgoCD.Client.Models.Session.Requests;
using ArgoCD.Client.Models.Session.Responses;

namespace ArgoCD.Client
{
    public interface ISessionClient
    {
        /// <summary>
        /// Get the current user's info
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<UserInfo> GetCurrentUserInfoAsync(CancellationToken cancellationToken = default);


        /// <summary>
        /// Create a new JWT for authentication and set a cookie if using HTTP
        /// </summary>
        /// <param name="request">Create session request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<Session> CreateSessionAsync(CreateSessionRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete an existing JWT cookie if using HTTP
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<Session> DeleteCurrentSessionAsync(CancellationToken cancellationToken = default);
    }
}
