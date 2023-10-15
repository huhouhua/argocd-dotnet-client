using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Requests
{
    public sealed class ApplicationWatchQueryOptions

    {
        public ApplicationWatchQueryOptions() { }

        public string Name { get; set; }

        public string Refresh { get; set; }

        public List<string> Projects { get; set; }

        public string ResourceVersion { get; set; }

        public string Selector { get; set; }

        public string Repo { get; set; }

        public string AppNamespace { get; set; }

        public List<string> Project { get; set; }
    }
}
