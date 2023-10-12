using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

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


        /// <summary>
        /// Values contains key/value pairs which are passed directly as parameters to the template. These values will not be sent as parameters to the plugin.
        /// </summary>
        public Dictionary<string, string> Values { get; set; }
    }
}
