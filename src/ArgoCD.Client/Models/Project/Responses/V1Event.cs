using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    /// <summary>
    /// Event is a report of an event somewhere in the cluster. Events
    /// have a limited retention time and triggers and messages may evolve
    /// with time. Event consumers should not rely on the timing of an event
    /// with a given Reason reflecting a consistent underlying trigger, or the
    /// continued existence of events with that Reason. Events should be
    /// treated as informative, best-effort, supplemental data.
    /// </summary>
    public class V1Event
    {
        public V1Event() { }


        /// <summary>
        /// What action was taken/failed regarding to the Regarding object. +optional
        /// </summary>
        public string Action { get; set; }


        /// <summary>
        /// The number of times this event has occurred. +optional
        /// </summary>
        public int Count { get; set; }


        /// <summary>
        /// The number of times this event has occurred. +optional
        /// </summary>
        public V1MicroTime EventTime { get; set; }


        public V1Time FirstTimestamp { get; set; }
    }
}
