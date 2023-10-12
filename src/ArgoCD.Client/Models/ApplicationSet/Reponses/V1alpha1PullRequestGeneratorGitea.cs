using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// PullRequestGeneratorGitea defines connection info specific to Gitea.
    /// </summary>
    public class V1alpha1PullRequestGeneratorGitea
    {
        /// <summary>
        /// Gets or Sets Api
        /// </summary>
        public string Api { get; set; }

        /// <summary>
        /// Allow insecure tls, for self-signed certificates; default: false.
        /// </summary>
        public bool Insecure { get; set; }

        /// <summary>
        /// Gitea org or user to scan. Required.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Gitea repo name to scan. Required.
        /// </summary>

        public string Repo { get; set; }

        public V1alpha1SecretRef TokenRef { get; set; }
    }
}
