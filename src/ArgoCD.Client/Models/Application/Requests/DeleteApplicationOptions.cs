using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Requests
{
    public sealed class DeleteApplicationOptions
    {
        public DeleteApplicationOptions() { }

        public bool Cascade { get; set; }

        public string PropagationPolicy { get; set; }

        public string AppNamespace { get; set; }

        public string Project { get; set; }
    }
}
