using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1PullRequestGeneratorBitbucketServer
    {
        /// <summary>
        /// The Bitbucket REST API URL to talk to e.g. https://bitbucket.org/rest Required.
        /// </summary>
        public string Api { get; set; }


        public V1alpha1BasicAuthBitbucketServer BasicAuth { get; set; }

        /// <summary>
        /// Project to scan. Required.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Repo name to scan. Required.
        /// </summary>
        public string Repo { get; set; }

    }
}
