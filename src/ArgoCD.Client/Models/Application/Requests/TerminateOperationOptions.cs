using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Requests
{
    public sealed class TerminateOperationOptions
    {
        public TerminateOperationOptions() { }

        public string AppNamespace { get; set; }

        public string Project { get; set; }

    }
}
