using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ApplicationSource
    {
        public V1alpha1ApplicationSource() { }

        public string Chart { get; set; }

        /// <summary>
        /// ApplicationSourceDirectory holds options for applications of type plain YAML or Jsonnet
        /// </summary>
        public string Directory { get; set; }
    }
}
