using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Cluster.Requests
{
    public sealed class ClusterQueryOptions
    {
        public ClusterQueryOptions() { }

        public string Server { get; set; }

        public string Name { get; set; }


        /// <summary>
        /// type is the type of the specified cluster identifier ( "server" - default, "name" ).
        /// </summary>
        public string IdType { get; set; }

        /// <summary>
        /// value holds the cluster server URL or cluster name.
        /// </summary>
        public string IdValue { get; set; }
    }
}
