using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Cluster.Responses
{
    public class V1alpha1ClusterInfo
    {
        public V1alpha1ClusterInfo() { }

        /// <summary>
        /// APIVersions contains list of API versions supported by the cluster
        /// </summary>
        public string[] ApiVersions { get; set; }

        /// <summary>
        ///  ApplicationsCount is the number of applications managed by Argo CD on the cluster
        /// </summary>
        public string ApplicationsCount { get; set; }

        /// <summary>
        /// ClusterCacheInfo contains information about the cluster cache
        /// </summary>
        public V1alpha1ClusterCacheInfo CacheInfo { get;}


        /// <summary>
        /// ConnectionState contains information about remote resource connection state, currently used for clusters and repositories
        /// </summary>
        public V1alpha1ConnectionState ConnectionState { get; }

        /// <summary>
        ///  ServerVersion contains information about the Kubernetes version of the cluster
        /// </summary>
        public string ServerVersion { get; set; }
    }
}
