using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// ApplicationSetCondition contains details about an applicationset condition, which is usally an error or warning
    /// </summary>
    public class V1alpha1ApplicationSetCondition
    {
        /// <summary>
        ///Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>
        public DateTimeOffset LastTransitionTime { get; set; }

        /// <summary>
        /// Message contains human-readable message indicating details about condition
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        ///Single word camelcase representing the reason for the status eg ErrorOccurred
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// True/False/Unknown
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Type is an applicationset condition type
        /// </summary>
        public string Type { get; set; }
    }
}
