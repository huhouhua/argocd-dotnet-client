using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Models.ApplicationSet.Reponses;

namespace ArgoCD.Client.Models.ApplicationSet.Requests
{
    public class CreateApplicationSetRequest
    {
        public CreateApplicationSetRequest() { }

        public V1alpha1ApplicationSet ApplicationSet { get; set; }
    }
}
