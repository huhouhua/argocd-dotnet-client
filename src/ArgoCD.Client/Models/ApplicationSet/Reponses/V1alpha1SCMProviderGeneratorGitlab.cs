using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// SCMProviderGeneratorGitlab defines connection info specific to Gitlab.
    /// </summary>
    public class V1alpha1SCMProviderGeneratorGitlab
    {
        /// <summary>
        /// Scan all branches instead of just the default branch.
        /// </summary>
        public bool AllBranches { get; set; }

        /// <summary>
        /// The Gitlab API URL to talk to.
        /// </summary>
        public string Api { get; set; }

        /// <summary>
        /// Gitlab group to scan. Required.  You can use either the project id (recommended) or the full namespaced path.
        /// </summary>
        public string Group { get; set; }


        public bool IncludeSubgroups { get; set; }


        public bool Insecure { get; set; }

        public V1alpha1SecretRef TokenRef { get; set; }
    }
}
