using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Cluster.Responses
{
    /// <summary>
    /// ClusterList is a collection of Clusters.
    /// </summary>
    public class V1alpha1ClusterList
    {
        public V1alpha1ClusterList() { }

        /// <summary>
        /// Cluster is the definition of a cluster resource
        /// </summary>
        public V1alpha1Cluster[] Items { get; set; }

        /// <summary>
        ///ListMeta describes metadata that synthetic resources must have, including lists and
        ///various status objects.A resource may have only one of {ObjectMeta, ListMeta}
        /// </summary>
        public V1ListMeta MetaData { get; set; }
    }
}
