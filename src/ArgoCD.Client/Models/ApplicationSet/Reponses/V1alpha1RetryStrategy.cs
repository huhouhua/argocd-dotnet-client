using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1RetryStrategy
    {
        public V1alpha1RetryStrategy() { }

        /// <summary>
        /// Backoff is the backoff strategy to use on subsequent retries for failing syncs
        /// </summary>
        public V1alpha1Backoff Backoff { get; set; }

        /// <summary>
        /// Limit is the maximum number of attempts for retrying a failed sync. If set to 0, no retries will be performed.
        /// </summary>
        public string Limit { get; set; }
    }
}
