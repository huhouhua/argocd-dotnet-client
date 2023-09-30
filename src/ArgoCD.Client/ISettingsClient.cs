using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArgoCD.Client.Models.Settings.Responses;

namespace ArgoCD.Client
{
    public interface ISettingsClient
    {
        /// <summary>
        /// Get returns Argo CD settings
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ClusterSettings> GetSettingsAsync(CancellationToken cancellationToken = default);
    }
}
