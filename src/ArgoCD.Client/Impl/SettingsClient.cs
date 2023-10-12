using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Models.Settings.Responses;

namespace ArgoCD.Client.Impl
{
    public class SettingsClient : ISettingsClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;

        internal SettingsClient(IArgoCDHttpFacade httpFacade) => _httpFacade = httpFacade;

        /// <summary>
        /// Get returns Argo CD settings
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ClusterSettings> GetSettingsAsync(CancellationToken cancellationToken = default) =>
            await _httpFacade.GetAsync<ClusterSettings>("settings", cancellationToken).
            ConfigureAwait(false);


        /// <summary>
        /// Get returns Argo CD plugins
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ClusterSettingsPlugins> GetPluginsAsync(CancellationToken cancellationToken = default) =>
            await _httpFacade.GetAsync<ClusterSettingsPlugins>("settings/plugins", cancellationToken).
            ConfigureAwait(false);

    }
}
