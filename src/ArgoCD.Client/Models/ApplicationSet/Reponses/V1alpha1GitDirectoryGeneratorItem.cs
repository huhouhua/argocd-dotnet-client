using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1GitDirectoryGeneratorItem
    {
        public bool Exclude { get; set; }

        public string Path { get; set; }
    }
}
