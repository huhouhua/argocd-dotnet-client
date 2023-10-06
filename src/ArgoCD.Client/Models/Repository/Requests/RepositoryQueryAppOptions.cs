using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Requests
{
    public sealed class RepositoryQueryAppOptions
    {
        public RepositoryQueryAppOptions() { }

        public string Revision { get; set; }

        public string AppName { get; set; }

        public string AppProject { get; set; }

    }
}
