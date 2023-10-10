using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1GitGenerator
    {
        public V1alpha1GitGenerator() { }

        public V1alpha1GitDirectoryGeneratorItem[] Directories { get; set; }

        public V1alpha1GitFileGeneratorItem[] Files { get; set; }

        public string RepoURL { get; set; }

        public string RequeueAfterSeconds { get; set; }

        public string Revision { get; set; }

        /// <summary>
        /// ApplicationSetTemplate represents argocd ApplicationSpec
        /// </summary>
        public V1alpha1ApplicationSetTemplate Template { get; set; }

        /// <summary>
        /// Values contains key/value pairs which are passed directly as parameters to the template
        /// </summary>
        public object Values { get; set; }
    }
}
