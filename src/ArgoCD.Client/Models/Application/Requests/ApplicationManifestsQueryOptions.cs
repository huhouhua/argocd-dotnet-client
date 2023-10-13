using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Requests
{
    public sealed class ApplicationManifestsQueryOptions
    {
        public ApplicationManifestsQueryOptions() { }

        public string Revision { get; set; }

        public string AppNamespace { get; set; }

        public string Project { get; set; }
    }
}
