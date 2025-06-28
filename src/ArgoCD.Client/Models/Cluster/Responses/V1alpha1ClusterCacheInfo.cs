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

        /// <summary>
        ///Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>
        public DateTimeOffset LastCacheSyncTime { get; set; }

        /// <summary>
        /// ResourcesCount holds number of observed Kubernetes resources
        /// </summary>
        public string ResourcesCount { get; set; }
    }
}
