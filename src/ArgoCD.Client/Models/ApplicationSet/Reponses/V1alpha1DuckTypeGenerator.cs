using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// 	DuckType defines a generator to match against clusters registered with ArgoCD.
    /// </summary>
    public class V1alpha1DuckTypeGenerator
    {
        /// <summary>
        /// ConfigMapRef is a ConfigMap with the duck type definitions needed to retrieve the data this includes apiVersion(group/version),
        /// kind, matchKey and validation settings Name is the resource name of the kind, group and version, defined in
        /// the ConfigMapRef RequeueAfterSeconds is how long before the duckType will be rechecked for a chang
        /// </summary>
        public string ConfigMapRef { get; set; }

        /// <summary>
        /// A label selector is a label query over a set of resources. The result of matchLabels and
        /// matchExpressions are ANDed.An empty label selector matches all objects.A null
        /// label selector matches no objects. +structType=atomic
        /// </summary>
        public V1LabelSelector LabelSelector { get; set; }


        public string Name { get; set; }

        public string RequeueAfterSeconds { get; set; }

        public V1alpha1ApplicationSetTemplate Template { get; set; }
    }
}
