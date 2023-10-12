using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// ApplicationSetSyncPolicy configures how generated Applications will relate to their ApplicationSet.
    /// </summary>
    public class V1alpha1ApplicationSetSyncPolicy
    {
        /// <summary>
        /// ApplicationsSync represents the policy applied on the generated applications. Possible values are create-only, create-update, create-delete, sync +kubebuilder:validation:Optional +kubebuilder:validation:Enum=create-only;create-update;create-delete;sync
        /// </summary>
        public string ApplicationsSync { get; set; }

        /// <summary>
        /// PreserveResourcesOnDeletion will preserve resources on deletion. If PreserveResourcesOnDeletion is set to true, these Applications will not be deleted.
        /// </summary>
        public bool PreserveResourcesOnDeletion { get; set; }
    }
}
