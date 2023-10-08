using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1SyncPolicy
    {
        public V1alpha1SyncPolicy() { }


        /// <summary>
        /// SyncPolicyAutomated controls the behavior of an automated sync
        /// </summary>
        public V1alpha1SyncPolicyAutomated Automated { get; set; }

        public V1alpha1ManagedNamespaceMetadata ManagedNamespaceMetadata { get; set; }

        /// <summary>
        /// RetryStrategy contains information about the strategy to apply when a sync failed
        /// </summary>
        public V1alpha1RetryStrategy Retry { get; set; }

        /// <summary>
        /// Options allow you to specify whole app sync-options
        /// </summary>
        public string[] SyncOptions { get; set; }
    }
}
