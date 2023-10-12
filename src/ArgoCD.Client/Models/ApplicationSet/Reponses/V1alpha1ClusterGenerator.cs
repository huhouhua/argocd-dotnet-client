using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// ClusterGenerator defines a generator to match against clusters registered with ArgoCD.
    /// </summary>
    public class V1alpha1ClusterGenerator
    {
        public V1alpha1ClusterGenerator() { }

        /// <summary>
        /// A label selector is a label query over a set of resources. The result of matchLabels and
        /// matchExpressions are ANDed.An empty label selector matches all objects.A null
        /// label selector matches no objects. +structType=atomic
        /// </summary>
        public V1LabelSelector Selector { get; set; }

        /// <summary>
        /// ApplicationSetTemplate represents argocd ApplicationSpec
        /// </summary>
        public V1alpha1ApplicationSetTemplate Template { get; set; }

        /// <summary>
        /// Values contains key/value pairs which are passed directly as parameters to the template
        /// </summary>
        public Dictionary<string, string> Values { get; set; }
    }
}
