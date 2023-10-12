using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ApplicationSummary
    {
        /// <summary>
        /// ExternalURLs holds all external URLs of application child resources.
        /// </summary>
        public string[] ExternalURLs { get; set; }

        /// <summary>
        /// Images holds all images of application child resources.
        /// </summary>
        public string[] Images { get; set; }
    }
}
