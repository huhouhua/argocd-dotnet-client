using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// 	PullRequestGenerator defines a generator that scrapes a PullRequest API to find candidate pull requests.
    /// </summary>
    public class V1alpha1PullRequestGenerator
    {
        public V1alpha1PullRequestGenerator() { }


        public V1alpha1PullRequestGeneratorAzureDevOps Azuredevops { get; set; }

    }
}
