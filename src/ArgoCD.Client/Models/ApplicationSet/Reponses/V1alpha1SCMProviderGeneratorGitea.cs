using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// SCMProviderGeneratorGitea defines a connection info specific to Gitea.
    /// </summary>
    public class V1alpha1SCMProviderGeneratorGitea
    {
        /// <summary>
        /// Scan all branches instead of just the default branch.
        /// </summary>
        public bool AllBranches { get; set; }

        /// <summary>
        /// The Gitea URL to talk to. For example https://gitea.mydomain.com/.
        /// </summary>
        public string Api { get; set; }


        public bool Insecure { get; set; }

        /// <summary>
        /// Gitea organization or user to scan. Required.
        /// </summary>
        public string Owner { get; set; }

        public V1alpha1SecretRef TokenRef { get; set; }
    }
}
