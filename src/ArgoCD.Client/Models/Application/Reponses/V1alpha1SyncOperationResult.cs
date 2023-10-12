using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;
using ArgoCD.Client.Models.ApplicationSet.Reponses;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1SyncOperationResult
    {
 
        public V1alpha1ManagedNamespaceMetadata ManagedNamespaceMetadata { get; set; }


        public V1alpha1ResourceResult[] Resources { get; set; }


        public string Revision { get; set; }


        public string[] Revisions { get; set; }

   
        public V1alpha1ApplicationSource Source { get; set; }

        public V1alpha1ApplicationSource[] Sources { get; set; }
    }
}
