using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1alpha1ApplicationDestination
    {
        public V1alpha1ApplicationDestination() { }

        /// <summary>
        /// Name is an alternate way of specifying the target cluster by its symbolic name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Namespace specifies the target namespace for the application's resources. The namespace will only be set for namespace-scoped resources that have not set a value for .metadata.namespace
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Server specifies the URL of the target cluster and must be set to the Kubernetes control plane API
        /// </summary>
        public string Server { get; set; }
    }
}
