using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ResourceNode
    {
        /// <summary>
        ///Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }


        public V1alpha1HealthStatus Health { get; set; }


        public string[] Images { get; set; }


        public V1alpha1InfoItem[] Info { get; set; }


        public V1alpha1ResourceNetworkingInfo NetworkingInfo { get; set; }


        public V1alpha1ResourceRef[] ParentRefs { get; set; }


        public V1alpha1ResourceRef ResourceRef { get; set; }


        public string ResourceVersion { get; set; }

    }
}
