using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ApplicationSetGenerator
    {
        /// <summary>
        /// 	DuckType defines a generator to match against clusters registered with ArgoCD
        /// </summary>
        public V1alpha1DuckTypeGenerator ClusterDecisionResource { get; set; }

        /// <summary>
        ///  ClusterGenerator defines a generator to match against clusters registered with ArgoCD
        /// </summary>
        public V1alpha1ClusterGenerator Clusters { get; set; }
    }
}
