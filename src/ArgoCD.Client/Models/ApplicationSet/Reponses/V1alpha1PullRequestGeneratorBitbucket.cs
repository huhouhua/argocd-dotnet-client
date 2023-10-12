using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// PullRequestGeneratorBitbucket defines connection info specific to Bitbucket.
    /// </summary>
    public class V1alpha1PullRequestGeneratorBitbucket
    {
        /// <summary>
        /// The Bitbucket REST API URL to talk to. If blank, uses https://api.bitbucket.org/2.0.
        /// </summary>
        public string Api { get; set; }


        public V1alpha1BasicAuthBitbucketServer BasicAuth { get; set; }


        public V1alpha1BearerTokenBitbucketCloud BearerToken { get; set; }

        /// <summary>
        /// Workspace to scan. Required.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Repo name to scan. Required.
        /// </summary>
        public string Repo { get; set; }
    }
}
