using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Requests
{
    public sealed class RepositoryQueryOptions
    {
        public RepositoryQueryOptions() { }

        /// <summary>
        /// Repo URL for query.
        /// </summary>
        public string Repo { get; set; }

        /// <summary>
        /// Whether to force a cache refresh on repo's connection state.
        /// </summary>
        public bool ForceRefresh { get; set; }
    }
}
