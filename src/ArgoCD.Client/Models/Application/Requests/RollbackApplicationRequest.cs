using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Requests
{
    public class RollbackApplicationRequest
    {
        public string AppNamespace { get; set; }

        public bool DryRun { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public bool Prune { get; set; }
    }
}
