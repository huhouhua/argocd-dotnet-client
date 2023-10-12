using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    /// <summary>
    /// LoadBalancerIngress represents the status of a load-balancer ingress point: traffic intended for the service should be sent to an ingress point.
    /// </summary>
    public class V1LoadBalancerIngress
    {

        public string Hostname { get; set; }


        public string Ip { get; set; }


        public V1PortStatus[] Ports { get; set; }
    }
}
