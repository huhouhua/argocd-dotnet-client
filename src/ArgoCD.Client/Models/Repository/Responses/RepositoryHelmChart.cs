using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Responses
{
    public  class RepositoryHelmChart
    {
        public string Name { get; set; }

        public string[] Versions { get; set; }
    }
}
