using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Models.Project.Responses;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ApplicationSet
    {
        public V1alpha1ApplicationSet() { }

        public V1ObjectMeta Metadata { get; set; }
    }
}
