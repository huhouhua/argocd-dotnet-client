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
        public V1Time LastTransitionTime { get; set; }

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
