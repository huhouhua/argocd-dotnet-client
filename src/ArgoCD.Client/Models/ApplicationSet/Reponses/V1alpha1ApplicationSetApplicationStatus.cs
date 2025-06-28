using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// ApplicationSetApplicationStatus contains details about each Application managed by the ApplicationSet
    /// </summary>
    public class V1alpha1ApplicationSetApplicationStatus
    {
        /// <summary>
        /// Application contains the name of the Application resource
        /// </summary>
        public string Application { get; set; }

        /// <summary>
        /// Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>
        public DateTimeOffset LastTransitionTime { get; set; }

        /// <summary>
        /// Message contains human-readable message indicating details about the status
        /// </summary>

        public string Message { get; set; }

        /// <summary>
        /// Status contains the AppSet's perceived status of the managed Application resource: (Waiting, Pending, Progressing, Healthy)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Step tracks which step this Application should be updated in
        /// </summary>
        public string Step { get; set; }

    }
}
