using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// PullRequestGeneratorFilter is a single pull request filter. If multiple filter types are set on a single struct, they will be AND&#39;d together. All filters must pass for a pull request to be included.
    /// </summary>
    public class V1alpha1PullRequestGeneratorFilter
    {

        public string BranchMatch { get; set; }

        public string TargetBranchMatch { get; set; }
    }
}
