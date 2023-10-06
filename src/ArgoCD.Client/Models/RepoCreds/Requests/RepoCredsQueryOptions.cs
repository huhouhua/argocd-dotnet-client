using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.RepoCreds.Requests
{
    public sealed class RepoCredsQueryOptions
    {
        public RepoCredsQueryOptions() { }

        /// <summary>
        /// Repo URL for query.
        /// </summary>
        public string Url { get; set; }

    }
}
