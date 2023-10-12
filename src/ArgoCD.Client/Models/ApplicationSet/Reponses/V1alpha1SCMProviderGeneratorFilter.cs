using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1SCMProviderGeneratorFilter
    {
        /// <summary>
        /// A regex which must match the branch name.
        /// </summary>
        public string BranchMatch { get; set; }

        /// <summary>
        /// A regex which must match at least one label.
        /// </summary>
        public string LabelMatch { get; set; }

        /// <summary>
        /// An array of paths, all of which must not exist.
        /// </summary>
        public List<string> PathsDoNotExist { get; set; }

        /// <summary>
        /// An array of paths, all of which must exist.
        /// </summary>
        public List<string> PathsExist { get; set; }

        /// <summary>
        /// A regex for repo names.
        /// </summary>
        public string RepositoryMatch { get; set; }
    }
}
