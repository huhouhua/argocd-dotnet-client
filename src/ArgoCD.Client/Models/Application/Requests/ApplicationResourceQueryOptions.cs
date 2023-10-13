using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Requests
{
    public sealed class ApplicationResourceQueryOptions
    {
        public ApplicationResourceQueryOptions() { }

        public string Namespace { get; set; }

        public string ResourceName { get; set; }

        public string Version { get; set; }


        public string Group { get; set; }


        public string Kind { get; set; }


        public string AppNamespace { get; set; }


        public string Project { get; set; }
    }
}
