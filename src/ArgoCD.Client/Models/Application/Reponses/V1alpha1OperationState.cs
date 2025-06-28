using System;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1OperationState
    {

        /// <summary>
        ///Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>
        public DateTimeOffset FinishedAt { get; set; }

        /// <summary>
        /// Message holds any pertinent messages when attempting to perform operation (typically errors).
        /// </summary>
        public string Message { get; set; }


        public V1alpha1Operation Operation { get; set; }

        public string Phase { get; set; }

        public string RetryCount { get; set; }


        /// <summary>
        ///Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>
        public DateTimeOffset StartedAt { get; set; }


        public V1alpha1SyncOperationResult SyncResult { get; set; }
    }
}
