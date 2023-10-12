using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// SCMProviderGeneratorGithub defines connection info specific to GitHub.
    /// </summary>
    public class V1alpha1SCMProviderGeneratorGithub
    {
        /// <summary>
        /// Scan all branches instead of just the default branch.
        /// </summary>

        public bool AllBranches { get; set; }

        /// <summary>
        /// The GitHub API URL to talk to. If blank, use https://api.github.com/.
        /// </summary>
        public string Api { get; set; }

        /// <summary>
        /// AppSecretName is a reference to a GitHub App repo-creds secret.
        /// </summary>
        public string AppSecretName { get; set; }

        /// <summary>
        /// GitHub org to scan. Required.
        /// </summary>
        public string Organization { get; set; }

        public V1alpha1SecretRef TokenRef { get; set; }
    }
}
