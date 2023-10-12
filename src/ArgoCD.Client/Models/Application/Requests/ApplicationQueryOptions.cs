using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Requests
{
    public sealed class ApplicationQueryOptions
    {

        /// <summary>
        /// forces application reconciliation if set to true.
        /// </summary>
        public string Refresh { get; set; }

        /// <summary>
        /// the project names to restrict returned list applications.
        /// </summary>
        public List<string> Projects { get; set; }

        /// <summary>
        /// when specified with a watch call, shows changes that occur after that particular version of a resource.
        /// </summary>
        public string ResourceVersion { get; set; }

        /// <summary>
        /// the selector to restrict returned list to applications only with matched labels.
        /// </summary>
        public string Selector { get; set; }

        /// <summary>
        /// the repoURL to restrict returned list applications.
        /// </summary>
        public string Repo { get; set; }

        /// <summary>
        /// the application's namespace.
        /// </summary>
        public string AppNamespace { get; set; }

        /// <summary>
        /// the project names to restrict returned list applications (legacy name for backwards-compatibility).
        /// </summary>
        public List<string> Project { get; set; }

    }
}
