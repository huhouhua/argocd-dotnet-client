using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Settings.Responses
{
    public sealed class ClusterDexConfig
    {
        public ClusterConnector[] Connectors { get; set; }
    }
}
