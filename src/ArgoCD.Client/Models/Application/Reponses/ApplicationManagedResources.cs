using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class ApplicationManagedResources
    {
        public ApplicationManagedResources() { }

        public V1alpha1ResourceDiff[] Items { get; set; }
    }
}
