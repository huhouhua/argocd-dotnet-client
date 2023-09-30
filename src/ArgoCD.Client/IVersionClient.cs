using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArgoCD.Client.Models;

namespace ArgoCD.Client
{
    public interface IVersionClient
    {
        /// <summary>
        /// Version returns version information of the API server
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<VersionInfo> GetVersionAsync(CancellationToken cancellationToken =default);
    }
}
