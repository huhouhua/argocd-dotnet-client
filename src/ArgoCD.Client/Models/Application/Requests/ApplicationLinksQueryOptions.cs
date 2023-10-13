using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Requests
{
    public sealed class ApplicationLinksQueryOptions
    {
        public ApplicationLinksQueryOptions() { }

        public string Namespace { get; set; }


        public string Project { get; set; }
    }
}
