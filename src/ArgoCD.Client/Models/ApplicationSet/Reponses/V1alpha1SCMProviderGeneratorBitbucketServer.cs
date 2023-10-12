using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// SCMProviderGeneratorBitbucketServer defines connection info specific to Bitbucket Server.
    /// </summary>
    public class V1alpha1SCMProviderGeneratorBitbucketServer
    {
        /// <summary>
        /// Scan all branches instead of just the default branch.
        /// </summary>
        public bool AllBranches { get; set; }

        /// <summary>
        /// The Bitbucket Server REST API URL to talk to. Required.
        /// </summary>
        public string Api { get; set; }


        public V1alpha1BasicAuthBitbucketServer BasicAuth { get; set; }

        /// <summary>
        /// Project to scan. Required.
        /// </summary>
        public string Project { get; set; }
    }
}
