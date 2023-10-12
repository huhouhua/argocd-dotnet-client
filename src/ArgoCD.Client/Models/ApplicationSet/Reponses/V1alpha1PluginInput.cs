using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1PluginInput
    {
        public V1alpha1PluginInput() { }


        /// <summary>
        /// Parameters contains the information to pass to the plugin. It is a map. The keys must be strings, and the values can be any type.
        /// </summary>
        public Dictionary<string, V1JSON> Parameters { get; set; }
    }
}
