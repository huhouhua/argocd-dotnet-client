using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Requests
{
    public sealed class DeleteApplicationOperationOptions
    {
        public DeleteApplicationOperationOptions() { }

        public string AppNamespace { get; set; }

        public string Project { get; set; }

    }
}
