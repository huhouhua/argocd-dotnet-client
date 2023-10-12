using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;
using ArgoCD.Client.Models.ApplicationSet.Reponses;

namespace ArgoCD.Client.Models.Application.Reponses
{
    /// <summary>
    /// SyncOperation contains details about a sync operation.
    /// </summary>
    public class V1alpha1SyncOperation
    {

        public bool DryRun { get; set; }


        public string[] Manifests { get; set; }


        public bool Prune { get; set; }


        public V1alpha1SyncOperationResource[] Resources { get; set; }

        /// <summary>
        /// Revision is the revision (Git) or chart version (Helm) which to sync the application to If omitted, will use the revision specified in app spec.
        /// </summary>
        public string Revision { get; set; }

        /// <summary>
        /// Revisions is the list of revision (Git) or chart version (Helm) which to sync each source in sources field for the application to If omitted, will use the revision specified in app spec.
        /// </summary>
        public string[] Revisions { get; set; }


        public V1alpha1ApplicationSource Source { get; set; }


        public V1alpha1ApplicationSource[] Sources { get; set; }


        public string[] SyncOptions { get; set; }


        public V1alpha1SyncStrategy SyncStrategy { get; set; }
    }
}
