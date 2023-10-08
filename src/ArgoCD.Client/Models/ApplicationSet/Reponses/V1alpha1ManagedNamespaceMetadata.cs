using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ManagedNamespaceMetadata
    {
        public object Annotations { get; set; }

        public object Labels { get; set; }
    }
}
