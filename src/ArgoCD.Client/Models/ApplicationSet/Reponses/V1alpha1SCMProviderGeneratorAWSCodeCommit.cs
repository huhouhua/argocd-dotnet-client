using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1SCMProviderGeneratorAWSCodeCommit
    {

        /// <summary>
        /// Scan all branches instead of just the default branch.
        /// </summary>
        public bool AllBranches { get; set; }

        /// <summary>
        /// Region provides the AWS region to discover repos. if not provided, AppSet controller will infer the current region from environment.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Role provides the AWS IAM role to assume, for cross-account repo discovery if not provided, AppSet controller will use its pod/node identity to discover.
        /// </summary>
        public string Role { get; set; }

        public V1alpha1TagFilter[] TagFilters { get; set; }
    }
}
