using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Cluster.Requests
{
    public class CreateClusterOptions
    {
        public CreateClusterOptions() { }


        public bool Upsert { get; set; }
    }
}
