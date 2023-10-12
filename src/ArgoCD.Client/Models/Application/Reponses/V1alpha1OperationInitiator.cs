using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1OperationInitiator
    {
        /// <summary>
        /// Automated is set to true if operation was initiated automatically by the application controller.
        /// </summary>
        public bool Automated { get; set; }

        public string Username { get; set; }
    }
}
