using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ApplicationSourceDirectory
    {
        public string Exclude { get; set; }

        public string Include { get; set; }

        public V1alpha1ApplicationSourceJsonnet Jsonnet { get; set; }
    }
}
