using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Requests
{
    public class PatchApplicationRequest
    {
        public PatchApplicationRequest() { }

        public string AppNamespace { get; set; }

        public string Name { get; set; }

        public string Patch { get; set; }

        public string PatchType { get; set; }

        public string Project { get; set; }
    }
}
