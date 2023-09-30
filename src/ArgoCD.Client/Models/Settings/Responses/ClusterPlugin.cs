using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Settings.Responses
{
    public sealed class ClusterPlugin
    {
        /// <summary>
        /// the name of the plugin, e.g. "kasane"
        /// </summary>
        public string Name { get; set; }
    }
}
