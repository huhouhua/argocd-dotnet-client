using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

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

        public V1alpha1GitGenerator Git { get; set; }

        public V1alpha1ListGenerator List { get; set; }



        public V1alpha1MergeGenerator Merge { get; set; }


        public V1alpha1PluginGenerator Plugin { get; set; }

        public V1alpha1PullRequestGenerator PullRequest { get; set; }

 
        public V1alpha1SCMProviderGenerator ScmProvider { get; set; }


        public V1LabelSelector Selector { get; set; }
    }
}
