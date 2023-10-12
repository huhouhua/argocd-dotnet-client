using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// PullRequestGeneratorGitLab defines connection info specific to GitLab.
    /// </summary>
    public class V1alpha1PullRequestGeneratorGitLab
    {
        /// <summary>
        /// The GitLab API URL to talk to. If blank, uses https://gitlab.com/.
        /// </summary>
        public string Api { get; set; }

        public bool Insecure { get; set; }


        public string[] Labels { get; set; }

        /// <summary>
        /// GitLab project to scan. Required.
        /// </summary>
        public string Project { get; set; }

        public string PullRequestState { get; set; }


        public V1alpha1SecretRef TokenRef { get; set; }
    }
}
