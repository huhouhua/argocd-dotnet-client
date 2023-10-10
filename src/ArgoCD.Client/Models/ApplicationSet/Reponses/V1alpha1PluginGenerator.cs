using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1PluginGenerator
    {
        public V1alpha1PluginGenerator() { }

        public V1alpha1PluginConfigMapRef ConfigMapRef { get; set; }

        public V1alpha1PluginInput Input { get; set; }

        /// <summary>
        /// RequeueAfterSeconds determines how long the ApplicationSet controller will wait before reconciling the ApplicationSet again.
        /// </summary>
        public string RequeueAfterSeconds { get; set; }

        public V1alpha1ApplicationSetTemplate Template { get; set; }

        public object Values { get; set; }
    }
}
