using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ApplicationCondition
    {

        /// <summary>
        ///Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>
        public DateTimeOffset LastTransitionTime { get; set; }

        public string Message { get; set; }

        public string Type { get; set; }
    }
}
