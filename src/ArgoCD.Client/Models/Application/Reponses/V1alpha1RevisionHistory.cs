using System;
using ArgoCD.Client.Models.ApplicationSet.Reponses;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1RevisionHistory
    {

        /// <summary>
        ///Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>
        public DateTimeOffset DeployStartedAt { get; set; }

        /// <summary>
        ///Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>

        public DateTimeOffset DeployedAt { get; set; }

        public string Id { get; set; }

        public string Revision { get; set; }

        public string[] Revisions { get; set; }


        public V1alpha1ApplicationSource Source { get; set; }


        public V1alpha1ApplicationSource[] Sources { get; set; }
    }
}
