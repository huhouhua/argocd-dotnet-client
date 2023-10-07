using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Requests
{
    public sealed class ApplicationSetQueryOptions
    {
        public ApplicationSetQueryOptions() { }

        /// <summary>
        /// the project names to restrict returned list applicationsets.
        /// </summary>
        public string[] Projects { get; set; }

        /// <summary>
        /// the selector to restrict returned list to applications only with matched labels.
        /// </summary>
        public string Selector { get; set; }

        /// <summary>
        /// The application set namespace. Default empty is argocd control plane namespace.
        /// </summary>
        public string AppsetNamespace { get; set; }
    }
}
