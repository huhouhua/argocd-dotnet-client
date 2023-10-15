using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Requests
{
    public sealed class ApplicationDetailsQueryOptions
    {
        public ApplicationDetailsQueryOptions() { }


        /// <summary>
        /// the application's namespace.
        /// </summary>
        public string AppNamespace { get; set; }

        public string Project { get; set; }
    }
}
