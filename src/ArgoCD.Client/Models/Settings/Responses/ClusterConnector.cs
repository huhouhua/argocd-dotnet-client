using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Settings.Responses
{
    public sealed class ClusterConnector
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
