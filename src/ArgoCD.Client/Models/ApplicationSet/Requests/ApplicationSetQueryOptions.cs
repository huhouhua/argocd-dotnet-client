using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Requests
{
    public sealed class ApplicationSetQueryOptions
    {
        public ApplicationSetQueryOptions() { }

        /// <summary>
        /// The application set namespace. Default empty is argocd control plane namespace.
        /// </summary>
        public string AppsetNamespace { get; set; }
    }
}
