using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1SyncStrategyApply
    {
        /// <summary>
        /// Force indicates whether or not to supply the - -force flag to &#x60;kubectl apply&#x60;. The - -force flag deletes and re-create the resource, when PATCH encounters conflict and has retried for 5 times.
        /// </summary>
        public bool Force { get; set; }
    }
}
