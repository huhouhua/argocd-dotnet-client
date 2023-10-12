using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1SCMProviderGenerator
    {
        public V1alpha1SCMProviderGeneratorAWSCodeCommit AwsCodeCommit { get; set; }

        public V1alpha1SCMProviderGeneratorAzureDevOps AzureDevOps { get; set; }


        public V1alpha1SCMProviderGeneratorBitbucket Bitbucket { get; set; }


        public V1alpha1SCMProviderGeneratorBitbucketServer BitbucketServer { get; set; }

        /// <summary>
        /// Which protocol to use for the SCM URL. Default is provider-specific but ssh if possible. Not all providers necessarily support all protocols.
        /// </summary>
        public string CloneProtocol { get; set; }

        /// <summary>
        /// Filters for which repos should be considered.
        /// </summary>
        public V1alpha1SCMProviderGeneratorFilter[] Filters { get; set; }


        public V1alpha1SCMProviderGeneratorGitea Gitea { get; set; }

        public V1alpha1SCMProviderGeneratorGithub Github { get; set; }


        public V1alpha1SCMProviderGeneratorGitlab Gitlab { get; set; }

        /// <summary>
        /// Standard parameters.
        /// </summary>
        public string RequeueAfterSeconds { get; set; }


        public V1alpha1ApplicationSetTemplate Template { get; set; }

        public Dictionary<string, string> Values { get; set; }
    }
}
