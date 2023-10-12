using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class DeleteApplicationSetResult
    {
        public V1alpha1ApplicationSet Applicationset { get; set; }


        public string Project { get; set; }
    }
}
