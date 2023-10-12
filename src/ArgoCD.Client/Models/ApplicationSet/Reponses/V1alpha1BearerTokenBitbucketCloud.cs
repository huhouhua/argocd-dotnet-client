using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// BearerTokenBitbucketCloud defines the Bearer token for BitBucket AppToken auth.
    /// </summary>
    public class V1alpha1BearerTokenBitbucketCloud
    {
        public V1alpha1SecretRef TokenRef { get; set; }
    }
}
