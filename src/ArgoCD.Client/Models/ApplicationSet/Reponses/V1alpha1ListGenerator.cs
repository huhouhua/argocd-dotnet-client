using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ListGenerator
    {
        public V1alpha1ListGenerator() { }

        public V1JSON[] Elements { get; set; }

        public string ElementsYaml { get; set; }

        /// <summary>
        /// ApplicationSetTemplate represents argocd ApplicationSpec
        /// </summary>
        public V1alpha1ApplicationSetTemplate Template { get; set; }
    }
}
