using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ResourceNetworkingInfo
    {
        /// <summary>
        /// ExternalURLs holds list of URLs which should be available externally. List is populated for ingress resources using rules hostnames.
        /// </summary>
        public string[] ExternalURLs { get; set; }


        public V1LoadBalancerIngress[] Ingress { get; set; }


        public Dictionary<string, string> Labels { get; set; }


        public Dictionary<string, string> TargetLabels { get; set; }


        public V1alpha1ResourceRef[] TargetRefs { get; set; }
    }
}
