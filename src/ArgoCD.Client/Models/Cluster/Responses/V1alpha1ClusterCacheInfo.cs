using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Cluster.Responses
{
    public class V1alpha1ClusterCacheInfo
    {
        /// <summary>
        /// APIsCount holds number of observed Kubernetes API count
        /// </summary>
        public string ApisCount { get; set; }

        public V1Time LastCacheSyncTime { get; set; }

        /// <summary>
        /// ResourcesCount holds number of observed Kubernetes resources
        /// </summary>
        public string ResourcesCount { get; set; }
    }
}
