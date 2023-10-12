using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// SCMProviderGeneratorBitbucket defines connection info specific to Bitbucket Cloud (API version 2).
    /// </summary>
    public class V1alpha1SCMProviderGeneratorBitbucket
    {

        /// <summary>
        /// Scan all branches instead of just the main branch.
        /// </summary>
        public bool AllBranches { get; set; }


        public V1alpha1SecretRef AppPasswordRef { get; set; }

        /// <summary>
        /// Bitbucket workspace to scan. Required.
        /// </summary>
        public string Owner { get; set; }

        public string User { get; set; }
    }
}
