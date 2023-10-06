using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Cluster.Requests
{
    public class UpdateClusterOptions
    {
        /// <summary>
        /// value holds the cluster server URL or cluster name
        /// </summary>
        public string IdType { get; set; }

        public string[] UpdatedFields { get; set; }
        /// <summary>
        /// value holds the cluster server URL or cluster name.
        /// </summary>
        public string IdValue { get; set; }
    }
}
