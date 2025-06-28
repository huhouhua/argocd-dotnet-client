using System;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class ApplicationLogEntry
    {

        public string Content { get; set; }


        public bool Last { get; set; }


        public string PodName { get; set; }

        /// <summary>
        ///Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>

        public DateTimeOffset TimeStamp { get; set; }


        public string TimeStampStr { get; set; }
    }
}
