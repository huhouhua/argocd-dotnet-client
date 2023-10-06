using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Requests
{
    public sealed class RepositoryRefreshOptions
    {
        public RepositoryRefreshOptions() { }


        /// <summary>
        /// Whether to force a cache refresh on repo's connection state.
        /// </summary>
        public bool ForceRefresh { get; set; }
    }
}
