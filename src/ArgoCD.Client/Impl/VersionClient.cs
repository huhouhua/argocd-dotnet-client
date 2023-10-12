using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Models;

namespace ArgoCD.Client.Impl
{
    public class VersionClient : IVersionClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;

        internal VersionClient(IArgoCDHttpFacade httpFacade) => _httpFacade = httpFacade;


        /// <summary>
        /// Version returns version information of the API server
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<VersionInfo> GetVersionAsync(CancellationToken cancellationToken = default)=>
            await _httpFacade.GetAsync<VersionInfo>("version", cancellationToken).
            ConfigureAwait(false);
    }
}
