using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// 	ApplicationSetNestedGenerator represents a generator nested within a combination-type generator(MatrixGenerator or MergeGenerator).
    /// </summary>
    public class V1alpha1ApplicationSetNestedGenerator
    {
        public V1alpha1DuckTypeGenerator ClusterDecisionResource { get; set; }

        public V1alpha1ClusterGenerator Clusters { get; set; }

        public V1alpha1GitGenerator Git { get; set; }

        public V1alpha1ListGenerator List { get; set; }

        public V1JSON Matrix { get; set; }

        public V1JSON Merge { get; set; }

        public V1alpha1PluginGenerator Plugin { get; set; }

        public V1alpha1PullRequestGenerator PullRequest { get; set; }

        public V1alpha1SCMProviderGenerator ScmProvider { get; set; }

        public V1LabelSelector Selector { get; set; }

    }
}
