using System;
using System.Collections.Generic;
using System.Text;
using static ArgoCD.Client.Models.Settings.Responses.ClusterSettings;

namespace ArgoCD.Client.Models.Settings.Responses
{
    public sealed class ConfigmanagementPlugin
    {
        /// <summary>
        /// Command holds binary path and arguments list
        /// </summary>
        public V1alpha1Command Generate { get; set; }

        /// <summary>
        /// Command holds binary path and arguments list
        /// </summary>
        public V1alpha1Command Init { get; set; }
        public bool LockRepo { get; set; }
        public string Name { get; set; }
    }
}
