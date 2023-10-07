using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Requests
{
    public sealed class DeleteProjectTokenOptions
    {
        public DeleteProjectTokenOptions() { }

        public string Id { get; set; }
    }
}
