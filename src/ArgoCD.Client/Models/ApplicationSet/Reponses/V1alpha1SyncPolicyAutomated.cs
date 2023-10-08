using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// SyncPolicyAutomated controls the behavior of an automated sync
    /// </summary>
    public class V1alpha1SyncPolicyAutomated
    {
        /// <summary>
        /// AllowEmpty allows apps have zero live resources (default: false)
        /// </summary>
        public bool AllowEmpty { get; set; }

        /// <summary>
        /// Prune specifies whether to delete resources from the cluster that are not found in the sources anymore as part of automated sync (default: false)
        /// </summary>
        public bool Prune { get; set; }


        /// <summary>
        /// SelfHeal specifies whether to revert resources back to their desired state upon modification in the cluster (default: false)
        /// </summary>
        public bool SelfHeal { get; set; }
    }
}
