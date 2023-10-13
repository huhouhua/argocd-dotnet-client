using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Requests
{
    public sealed class ApplicationEventOptions
    {
        public ApplicationEventOptions() { }

        public string ResourceNamespace { get; set; }


        public string ResourceName { get; set; }

        public string ResourceUID { get; set; }

        public string AppNamespace { get; set; }


        public string Project { get; set; }

    }
}
