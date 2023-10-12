using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// PullRequestGenerator defines connection info specific to GitHub.
    /// </summary>
    public class V1alpha1PullRequestGeneratorGithub
    {
        /// <summary>
        /// The GitHub API URL to talk to. If blank, use https://api.github.com/.
        /// </summary>
        public string Api { get; set; }

        /// <summary>
        /// AppSecretName is a reference to a GitHub App repo-creds secret with permission to access pull requests.
        /// </summary>

        public string AppSecretName { get; set; }


        public string[] Labels { get; set; }

        /// <summary>
        /// GitHub org or user to scan. Required.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// GitHub repo name to scan. Required.
        /// </summary>
        public string Repo { get; set; }


        public V1alpha1SecretRef TokenRef { get; set; }
    }
}
