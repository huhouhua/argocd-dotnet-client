using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Responses
{
    public class RepositoryRefs
    {
        public string[] Branches { get; set; }

        public string[] Tags { get; set; }

    }
}
