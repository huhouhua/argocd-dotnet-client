using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// 	PullRequestGenerator defines a generator that scrapes a PullRequest API to find candidate pull requests.
    /// </summary>
    public class V1alpha1PullRequestGenerator
    {
        public V1alpha1PullRequestGenerator() { }




        public V1alpha1PullRequestGeneratorAzureDevOps Azuredevops { get; set; }


        public V1alpha1PullRequestGeneratorBitbucket Bitbucket { get; set; }


        public V1alpha1PullRequestGeneratorBitbucketServer BitbucketServer { get; set; }

        /// <summary>
        /// Filters for which pull requests should be considered.
        /// </summary>
        public List<V1alpha1PullRequestGeneratorFilter> Filters { get; set; }


        public V1alpha1PullRequestGeneratorGitea Gitea { get; set; }


        public V1alpha1PullRequestGeneratorGithub Github { get; set; }


        public V1alpha1PullRequestGeneratorGitLab Gitlab { get; set; }

        /// <summary>
        /// Standard parameters.
        /// </summary>
        public string RequeueAfterSeconds { get; set; }


        public V1alpha1ApplicationSetTemplate Template { get; set; }

    }
}
