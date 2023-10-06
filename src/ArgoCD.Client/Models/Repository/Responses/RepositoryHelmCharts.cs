using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Responses
{
    public class RepositoryHelmCharts
    {
        public RepositoryHelmCharts() { }

        public RepositoryHelmChart[] Items { get; set; }
    }
}
