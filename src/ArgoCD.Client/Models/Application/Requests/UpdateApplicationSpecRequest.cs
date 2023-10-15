using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Models.ApplicationSet.Reponses;

namespace ArgoCD.Client.Models.Application.Requests
{
    public class UpdateApplicationSpecRequest
    {
        public V1alpha1ApplicationSpec ApplicationSpec { get; set; }
    }
}
