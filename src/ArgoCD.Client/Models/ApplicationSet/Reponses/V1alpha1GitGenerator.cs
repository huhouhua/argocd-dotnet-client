using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1GitGenerator
    {
        public V1alpha1GitGenerator() { }

        public V1alpha1GitDirectoryGeneratorItem[] Directories { get; set; }

        public int Files { get; set; }
    }
}
