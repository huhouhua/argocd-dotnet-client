using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// SCMProviderGeneratorAzureDevOps defines connection info specific to Azure DevOps.
    /// </summary>
    public class V1alpha1SCMProviderGeneratorAzureDevOps
    {

        public V1alpha1SecretRef AccessTokenRef { get; set; }

        /// <summary>
        /// Scan all branches instead of just the default branch.
        /// </summary>
        public bool AllBranches { get; set; }

        /// <summary>
        /// The URL to Azure DevOps. If blank, use https://dev.azure.com.
        /// </summary>
        public string Api { get; set; }

        /// <summary>
        /// Azure Devops organization. Required. E.g. \&quot;my-organization\&quot;.
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// Azure Devops team project. Required. E.g. \&quot;my-team\&quot;.
        /// </summary>
        public string TeamProject { get; set; }
    }
}
