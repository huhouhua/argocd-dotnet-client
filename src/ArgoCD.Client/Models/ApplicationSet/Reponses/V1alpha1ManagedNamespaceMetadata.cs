using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ManagedNamespaceMetadata
    {
        public Dictionary<string, string> Annotations { get; set; }
        public Dictionary<string, string> Labels { get; set; }
    }
}
